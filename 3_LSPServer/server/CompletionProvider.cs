using System;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System.Threading;
using parser;
using Bogus;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;

namespace server
{
    class CompletionProvider : CompletionHandlerBase<Data>
    {
        private readonly TextDocumentStore store;
        private readonly IOptionsMonitor<BdgConfiguration> options;

        public CompletionProvider(TextDocumentStore store, IOptionsMonitor<BdgConfiguration> options)
        {
            this.store = store;
            this.options = options;
        }

        protected override CompletionRegistrationOptions CreateRegistrationOptions(CompletionCapability capability, ClientCapabilities clientCapabilities)
        {
            return new CompletionRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector,
                ResolveProvider = true,
                TriggerCharacters = new Container<string>(new[] { "=", "[", ".", "[a-zA-Z]" }),
                AllCommitCharacters = new Container<string>(new[] { "\n" })
            };
        }

        protected override async Task<CompletionList<Data>> HandleParams(CompletionParams request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            if (!store.TryGetDocument(request.TextDocument.Uri, out var document)) return null;

            string s="";
            int i = 0;
            while(char.IsLetter(document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character-i))) ||
                    char.IsNumber(document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i))) ||
                    document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) == '.' ||
                    document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) == '[' ||
                    document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) == ']')
            {
                s = s.Insert(0, document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)).ToString());
                i++;
            }
            if(s.Contains("."))
            {
                string[] substrings = s.Split(".");
                if (substrings[substrings.Length-2]=="all")
                {
                    s = string.Join(".", substrings, substrings.Length - 3, substrings.Length - 2);
                }
                else
                    s = substrings[substrings.Length - 2];
                return document.GetKeywords(s);
            }

            return document.GetKeywords("");
        }

        protected override Task<CompletionItem<Data>> HandleResolve(CompletionItem<Data> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request);
        }
    }
}
