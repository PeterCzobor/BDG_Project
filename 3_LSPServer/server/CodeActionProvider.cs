using System;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using MediatR;
using System.Threading;
using parser;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using OmniSharp.Extensions.LanguageServer.Protocol.Workspace;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;
using System.Linq;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Newtonsoft.Json.Linq;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using Language;

namespace server
{
    class CodeActionProvider : ICodeActionHandler
    {
        private readonly TextDocumentStore store;

        public CodeActionProvider(TextDocumentStore store)
        {
            this.store = store;
        }

        public CodeActionRegistrationOptions GetRegistrationOptions(CodeActionCapability capability, ClientCapabilities clientCapabilities)
        {
            return new CodeActionRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector,
                ResolveProvider = true,
                CodeActionKinds = new Container<CodeActionKind>(
                CodeActionKind.Empty,
                CodeActionKind.QuickFix,
                CodeActionKind.Refactor,
                CodeActionKind.RefactorExtract,
                CodeActionKind.RefactorInline,
                CodeActionKind.RefactorRewrite,
                CodeActionKind.Source,
                CodeActionKind.SourceOrganizeImports
                )
            };
        }

        public Task<CommandOrCodeActionContainer> Handle(CodeActionParams request, CancellationToken cancellationToken)
        {
            if (!store.TryGetDocument(request.TextDocument.Uri, out var document)) return Task.FromResult<CommandOrCodeActionContainer>(null);
            
            var diagnostics = request.Context.Diagnostics;

            var errorCode = "";
            JToken errorData = null;

            if (diagnostics != null && diagnostics.Any())
            {
                errorCode = diagnostics.First().Code;
                errorData = diagnostics.First().Data;
            }

            if (errorCode == "BDGMIS")
            {

                return Task.FromResult(new CommandOrCodeActionContainer(new CommandOrCodeAction(new CodeAction<Data>()
                {
                    Title = "Add " + errorData,
                    Kind = CodeActionKind.QuickFix,
                    Edit = new WorkspaceEdit()
                    {
                        DocumentChanges = new Container<WorkspaceEditDocumentChange>(
                            new TextDocumentEdit()
                            {
                                TextDocument = new OptionalVersionedTextDocumentIdentifier()
                                {
                                    Uri = request.TextDocument.Uri,
                                    Version = document.Version
                                },
                                Edits = new TextEditContainer(
                                new TextEdit()
                                {
                                    NewText = errorData.ToString(),
                                    Range = request.Range
                                })
                            })
                    }
                })));

            }

            if (errorCode == "BDGTYP")
            {
                string similar = BdgDocument.CheckSimilarity(errorData.ToString());

                List<CommandOrCodeAction> actions = new List<CommandOrCodeAction>()
                {
                    new CommandOrCodeAction(new CodeAction<Data>()
                    {
                        Title = "Change  " + errorData + " to " + similar,
                        Kind = CodeActionKind.QuickFix,
                        Edit = new WorkspaceEdit()
                        {
                            DocumentChanges = new Container<WorkspaceEditDocumentChange>(
                            new TextDocumentEdit()
                            {
                                TextDocument = new OptionalVersionedTextDocumentIdentifier()
                                {
                                    Uri = request.TextDocument.Uri,
                                    Version = document.Version
                                },
                                Edits = new TextEditContainer(
                                    new TextEdit()
                                    {
                                        NewText = similar,
                                        Range = ((request.Range.Start.Line, request.Range.Start.Character), (request.Range.End.Line, request.Range.End.Character + errorData.ToString().Length)),
                                    })
                            })
                        }
                    })
                };
                return Task.FromResult(new CommandOrCodeActionContainer(actions.ToArray()));
            }

            if (errorCode == "BDGHNM")
            {
                List<CommandOrCodeAction> actions = new List<CommandOrCodeAction>();

                List<string> alternatives = GetAlternatives(errorData.ToString(), document);
                foreach (string alternative in alternatives)
                {
                    actions.Add(new CommandOrCodeAction(new CodeAction<Data>()
                    {
                        Title = alternative,
                        Kind = CodeActionKind.QuickFix,
                        Edit = new WorkspaceEdit()
                        {
                            DocumentChanges = new Container<WorkspaceEditDocumentChange>(
                            new TextDocumentEdit()
                            {
                                TextDocument = new OptionalVersionedTextDocumentIdentifier()
                                {
                                    Uri = request.TextDocument.Uri,
                                    Version = document.Version
                                },
                                Edits = new TextEditContainer(
                                    new TextEdit()
                                    {
                                        NewText = alternative,
                                        Range = ((request.Range.Start.Line, request.Range.Start.Character), (request.Range.End.Line, request.Range.End.Character + errorData.ToString().Length)),
                                    })
                            })
                        }
                    }));
                }
                return Task.FromResult(new CommandOrCodeActionContainer(actions.ToArray()));

            }

            if (errorCode == "BDGLAS")
            {
                string anyNone = "";
                if(errorData.ToString().Contains(".any"))
                {
                    anyNone = "any";
                }
                if (errorData.ToString().Contains(".none"))
                {
                    anyNone = "none";
                }
                string similar = BdgDocument.CheckSimilarity(errorData.ToString());

                List<CommandOrCodeAction> actions = new List<CommandOrCodeAction>()
                {
                    new CommandOrCodeAction(new CodeAction<Data>()
                    {
                        Title = "Change  " + anyNone + " to all",
                        Kind = CodeActionKind.QuickFix,
                        Edit = new WorkspaceEdit()
                        {
                            DocumentChanges = new Container<WorkspaceEditDocumentChange>(
                            new TextDocumentEdit()
                            {
                                TextDocument = new OptionalVersionedTextDocumentIdentifier()
                                {
                                    Uri = request.TextDocument.Uri,
                                    Version = document.Version
                                },
                                Edits = new TextEditContainer(
                                    new TextEdit()
                                    {
                                        NewText = errorData.ToString().Replace("."+anyNone, ".all"),
                                        Range = ((request.Range.Start.Line, request.Range.Start.Character), (request.Range.End.Line, request.Range.End.Character)),
                                    })
                            })
                        }
                    })
                };
                return Task.FromResult(new CommandOrCodeActionContainer(actions.ToArray()));
            }
            return Task.FromResult<CommandOrCodeActionContainer>(null);
        }

        public List<string> GetAlternatives(string attribute, BdgDocument document)
        {
            switch (attribute)
            {
                case "Player":
                    return new List<string> { "name", "pieces" };
                case "Piece":
                    return new List<string> { "posX", "posY", "texture", "color", "player" };
                case "Tile":
                    return new List<string> { "posX", "posY", "pieces", "empty" };

            }
            return new List<string>();
        }
    }
}
