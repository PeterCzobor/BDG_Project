using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System.Threading;
using parser;
using System.Drawing;
using System.Collections;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;

namespace server
{
    class HoverProvider : HoverHandlerBase
    {
        private readonly TextDocumentStore store;

        public HoverProvider(TextDocumentStore store)
        {
            this.store = store;
        }
        
        public override async Task<Hover> Handle(HoverParams request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            if (!store.TryGetDocument(request.TextDocument.Uri, out var document)) return null;
            var item = document.GetItemAtPosition(request.Position);
            return item switch
            {
                BdgValue v => new Hover()
                {
                    Contents = new MarkedStringsOrMarkupContent(
                        new MarkedString($"{VisitorHelper.GetValueString(v.Value)} {v.Key}\n\n{VisitorHelper.GetValueDetails(v.Key)}")
                    )
                },
                BdgColor c => new Hover()
                {
                    Contents = new MarkedStringsOrMarkupContent(
                        new MarkedString($"{VisitorHelper.classColor("Color")}: <span style=\"color:{c.Color};\">**▮**</span>")
                    )
                },
                BdgFunctionCall f => new Hover()
                {
                    Contents = new MarkedStringsOrMarkupContent(
                        new MarkedString(VisitorHelper.GetFuncString(f.Key) +"\n\n"+ VisitorHelper.GetFuncDetails(f.Key))
                    )
                },
                _ => null
            };
        }

        protected override HoverRegistrationOptions CreateRegistrationOptions(HoverCapability capability, ClientCapabilities clientCapabilities)
        {
            return new HoverRegistrationOptions()
            {
                DocumentSelector = store.GetRegistrationOptions().DocumentSelector
            };
        }
    }
}
