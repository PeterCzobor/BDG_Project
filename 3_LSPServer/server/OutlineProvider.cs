using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System.Threading;
using System.Linq;
using System.Buffers;
using System;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol;
using parser;
using Bogus.Bson;

namespace server
{
    class OutlineProvider : IDocumentSymbolHandler
    {
        private readonly TextDocumentStore store;

        public OutlineProvider(TextDocumentStore store)
        {
            this.store = store;
        }
        public async Task<SymbolInformationOrDocumentSymbolContainer> Handle(DocumentSymbolParams request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            if (!store.TryGetDocument(request.TextDocument.Uri, out var document)) return null;

            SymbolInformationOrDocumentSymbolContainer symbols = document.GetSections()
                .Where(x => !x.inSection)
                .Select(section =>
                {
                    return new SymbolInformationOrDocumentSymbol(new DocumentSymbol()
                    {
                        Name = section.Name,
                        Kind = section.type,
                        Range = (section.Location.Start, section.Location.End),
                        SelectionRange = section.Location,
                        Children = document.GetSections()
                            .Where(z => z.Location.Start >= section.Location.Start && z.Location.End <= section.Location.End && z != section)
                            .Select(value => new DocumentSymbol()
                            {
                                Name = value.Name,
                                Kind = value.type,
                                Range = (value.Location.Start, value.Location.End),
                                SelectionRange = value.Location
                            })
                            .ToArray()
                    });
                })
                .ToArray();

            return symbols;
        }

        public DocumentSymbolRegistrationOptions GetRegistrationOptions(DocumentSymbolCapability capability, ClientCapabilities clientCapabilities)
        {
            return new DocumentSymbolRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector,
                Label = "BDG"
            };
        }
    }
}
