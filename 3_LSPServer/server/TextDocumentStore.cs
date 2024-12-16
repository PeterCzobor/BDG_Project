using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol;
using MediatR;
using System.Threading;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Server.Capabilities;
using System.Linq;
using System.Collections.Immutable;
using parser;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using System.Buffers;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using StreamJsonRpc;
using System;
using OmniSharp.Extensions.JsonRpc;

namespace server
{
    class TextDocumentStore : ITextDocumentSyncHandler
    {
        private readonly TextDocumentChangeRegistrationOptions _options;
        private readonly TextDocumentCloseRegistrationOptions _closeoptions;
        private readonly TextDocumentOpenRegistrationOptions _openoptions;
        private readonly TextDocumentSaveRegistrationOptions _saveOptions;
        private readonly ILanguageServerFacade languageServer;
        private TextSynchronizationCapability _capability;
        private ImmutableDictionary<DocumentUri, BdgDocument> _openDocuments = ImmutableDictionary<DocumentUri, BdgDocument>.Empty.WithComparers(DocumentUri.Comparer);
        private ImmutableDictionary<DocumentUri, SemanticTokensDocument> _tokenDocuments = ImmutableDictionary<DocumentUri, SemanticTokensDocument>.Empty.WithComparers(DocumentUri.Comparer);

        public TextDocumentStore(ILanguageServerFacade languageServer)
        {
            _options = new TextDocumentChangeRegistrationOptions()
            {
                DocumentSelector = new TextDocumentSelector(TextDocumentSelector.ForPattern("**/*.bdg").Concat(TextDocumentSelector.ForScheme("bdg"))),
                SyncKind = TextDocumentSyncKind.Incremental
            };
            _saveOptions = new TextDocumentSaveRegistrationOptions()
            {
                DocumentSelector = _options.DocumentSelector,
                IncludeText = true
            };
            _closeoptions = new TextDocumentCloseRegistrationOptions()
            {
                DocumentSelector = _options.DocumentSelector,
            };
            _openoptions = new TextDocumentOpenRegistrationOptions()
            {
                DocumentSelector = _options.DocumentSelector,
            };
            _capability = new TextSynchronizationCapability()
            {
                DidSave = true,
                WillSave = true
            };
            this.languageServer = languageServer;
        }
#nullable enable
        public BdgDocument? GetDocument(DocumentUri documentUri)
        {
            return _openDocuments.TryGetValue(documentUri, out var value) ? value : null;
        }
#nullable disable

        public bool TryGetDocument(DocumentUri documentUri, out BdgDocument document)
        {
            return _openDocuments.TryGetValue(documentUri, out document);
        }

        public bool TryGetTokenDocument(DocumentUri documentUri, SemanticTokensRegistrationOptions options, out SemanticTokensDocument document)
        {
            if (_openDocuments.TryGetValue(documentUri, out _))
            {
                if (!_tokenDocuments.TryGetValue(documentUri, out document))
                    _tokenDocuments = _tokenDocuments.Add(documentUri, document = new SemanticTokensDocument(options));
                return true;
            }
            document = null;
            return false;
        }

        public TextDocumentAttributes GetTextDocumentAttributes(DocumentUri uri)
        {
            if (uri.Path.EndsWith(".bdg"))
            {
                return new TextDocumentAttributes(uri, "bdg");
            }
            return null;
        }

        public Task<Unit> Handle(DidChangeTextDocumentParams request, CancellationToken cancellationToken)
        {
            if (!_openDocuments.TryGetValue(request.TextDocument.Uri, out var value)) return Unit.Task;
            if (request.TextDocument.Uri.GetFileSystemPath().Contains("bdg"))
                value.IniJsonPath = request.TextDocument.Uri.GetFileSystemPath().Replace("bdg", "json");
            var changes = request.ContentChanges.ToArray();
            // full text change;
            if (changes.Length == 1 && changes[0].Range == default)
            {
                value.Load(changes[0].Text);
            }
            else
            {
                value.Update(changes);
            }
            languageServer.TextDocument.PublishDiagnostics(new PublishDiagnosticsParams()
            {
                Diagnostics = new Container<Diagnostic>(value.GetDiagnostics()),
                Uri = value.DocumentUri,
                Version = value.Version
            });
            return Unit.Task;
        }

        public Task<Unit> Handle(DidOpenTextDocumentParams request, CancellationToken cancellationToken)
        {
            lock (_openDocuments)
            {
                var document = new BdgDocument(request.TextDocument.Uri);
                _openDocuments = _openDocuments.Add(request.TextDocument.Uri, document);
                if (request.TextDocument.Uri.GetFileSystemPath().Contains("bdg"))
                    document.IniJsonPath = request.TextDocument.Uri.GetFileSystemPath().Replace("bdg", "json");
                document.Load(request.TextDocument.Text);

                languageServer.TextDocument.PublishDiagnostics(new PublishDiagnosticsParams()
                {
                    Diagnostics = new Container<Diagnostic>(document.GetDiagnostics()),
                    Uri = document.DocumentUri,
                    Version = document.Version
                });
            }

            return Unit.Task;
        }

        public Task<Unit> Handle(DidCloseTextDocumentParams request, CancellationToken cancellationToken)
        {
            lock (_openDocuments)
            {
                _openDocuments = _openDocuments.Remove(request.TextDocument.Uri);
            }

            return Unit.Task;
        }

        public async  Task<Unit> Handle(DidSaveTextDocumentParams request, CancellationToken cancellationToken)
        {
            if (!_capability.DidSave) return await Unit.Task;
            if (_openDocuments.TryGetValue(request.TextDocument.Uri, out var value))
            {
                value.Load(request.Text);

                /* Perform formatting before updating the document
                var edits = await FormatDocumentAsync(value, null); // Call formatting function
                foreach (var edit in edits)
                {
                await languageServer.Workspace.ApplyWorkspaceEdit(new ApplyWorkspaceEditParams()
                {
                    Edit = new WorkspaceEdit()
                    {
                        DocumentChanges = new Container<WorkspaceEditDocumentChange>(
                            new TextDocumentEdit()
                            {
                                TextDocument = new OptionalVersionedTextDocumentIdentifier()
                                {
                                    Uri = request.TextDocument.Uri,
                                    //Version = document.Version
                                },
                                Edits = new TextEditContainer(
                                    edit
                                )
                            }
                        )
                    }
                }, cancellationToken: cancellationToken);                }
                */
                languageServer.TextDocument.PublishDiagnostics(new PublishDiagnosticsParams()
                {
                    Diagnostics = new Container<Diagnostic>(value.GetDiagnostics()),
                    Uri = value.DocumentUri,
                    Version = value.Version
                });
            }

            return await Unit.Task;
        }

        public void SetCapability(TextSynchronizationCapability capability) { _capability = capability; }
        public TextDocumentChangeRegistrationOptions GetRegistrationOptions() { return _options; }

        public TextDocumentChangeRegistrationOptions GetRegistrationOptions(TextSynchronizationCapability capability, ClientCapabilities clientCapabilities)
        {
            return _options; 
        }

        TextDocumentOpenRegistrationOptions IRegistration<TextDocumentOpenRegistrationOptions, TextSynchronizationCapability>.GetRegistrationOptions(TextSynchronizationCapability capability, ClientCapabilities clientCapabilities)
        {
            return _openoptions;
        }

        TextDocumentCloseRegistrationOptions IRegistration<TextDocumentCloseRegistrationOptions, TextSynchronizationCapability>.GetRegistrationOptions(TextSynchronizationCapability capability, ClientCapabilities clientCapabilities)
        {
            return _closeoptions;
        }

        TextDocumentSaveRegistrationOptions IRegistration<TextDocumentSaveRegistrationOptions, TextSynchronizationCapability>.GetRegistrationOptions(TextSynchronizationCapability capability, ClientCapabilities clientCapabilities)
        {
            return _saveOptions;
        }
    }
}
