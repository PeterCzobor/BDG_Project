using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OmniSharp.Extensions.JsonRpc;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using parser;

namespace server
{
    class SignatureHelpProvider : SignatureHelpHandlerBase
    {
        private readonly TextDocumentStore store;
        SignatureInformationCapabilityOptions capability;
        //object func = null;

        public SignatureHelpProvider(TextDocumentStore store)
        { 
            this.store = store;
        }

        public async override Task<SignatureHelp> Handle(SignatureHelpParams request, CancellationToken token)
        {
            await Task.Yield();
            if (!store.TryGetDocument(request.TextDocument.Uri, out var document)) return null;
            int i = 0;
            while (document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) != '(')
            {
                if ((document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) == '\n') ||
                    (document.GetCharAtPosition(new Position(request.Position.Line, request.Position.Character - i)) == ';'))
                    break;
                i++;
            }

            object item = document.GetItemAtPosition(new Position(request.Position.Line, request.Position.Character - i - 1));
            if(item is BdgFunctionCall f)
            {
                var containerSignatures = new SignatureInformation
                {
                    Label = "",
                    Documentation = new StringOrMarkupContent(
                        new MarkupContent()
                        {
                            Kind = MarkupKind.Markdown,
                            Value = VisitorHelper.GetFuncString(f.Key)
                        }
                    )
                };

                var signatures = new Container<SignatureInformation>(containerSignatures);
                return new SignatureHelp
                {
                    Signatures = signatures
                };
            }
            return new SignatureHelp();
        }

       protected override SignatureHelpRegistrationOptions CreateRegistrationOptions(SignatureHelpCapability capability, ClientCapabilities clientCapabilities)
        {
            return new SignatureHelpRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector,
                TriggerCharacters = new Container<string>(new[] { "[","]","(",")", ",", ".",
                    "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                    "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                    "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }),
                

            };
        }
    }
}
