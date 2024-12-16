using System;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System.Threading;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using System.Linq;
using System.Collections.Immutable;
using parser;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Buffers;
using Antlr4.Runtime;
using Language;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;

namespace server
{
    class TokenProvider : SemanticTokensHandlerBase
    {
        private readonly TextDocumentStore store;

        SemanticTokensRegistrationOptions options;

        public TokenProvider(TextDocumentStore store, IOptionsMonitor<IniConfiguration> optionsMonitor, IWorkspaceLanguageServer textDocumentLanguageServer)
        {
            this.store = store;
        }

        protected override SemanticTokensRegistrationOptions CreateRegistrationOptions(SemanticTokensCapability capability, ClientCapabilities clientCapabilities)
        {
            options= new SemanticTokensRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector,
                Full = new SemanticTokensCapabilityRequestFull()
                {
                    Delta = false
                },
                Range = new SemanticTokensCapabilityRequestRange() { },
                Legend = new SemanticTokensLegend()
                {
                    TokenModifiers = capability.TokenModifiers,
                    TokenTypes = capability.TokenTypes,
                }
            };
            return options;
        }

        protected override Task<SemanticTokensDocument> GetSemanticTokensDocument(ITextDocumentIdentifierParams @params, CancellationToken cancellationToken)
            => Task.FromResult(new SemanticTokensDocument(options.Legend));

        protected override Task Tokenize(SemanticTokensBuilder builder, ITextDocumentIdentifierParams identifier, CancellationToken cancellationToken)
        {
            if (!store.TryGetDocument(identifier.TextDocument.Uri, out var document))
                return Task.CompletedTask;
            var text = document.GetText();

            var inputStream = new AntlrInputStream(text);
            var lexer = new Combined1Lexer(inputStream);

            lexer.RemoveErrorListeners();
            var tokens = new CommonTokenStream(lexer);
            var parser = new Combined1Parser(tokens);
            var tree = parser.program();
            TokenVisitor visitor = new TokenVisitor();
            visitor.builder = builder;
            visitor.Visit(tree);

            return Task.CompletedTask;
        }
    }
}
