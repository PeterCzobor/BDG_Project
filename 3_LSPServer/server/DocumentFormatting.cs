using MediatR;
using Newtonsoft.Json.Linq;
using OmniSharp.Extensions.JsonRpc;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Progress;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using OmniSharp.Extensions.LanguageServer.Protocol.Server.WorkDone;
using StreamJsonRpc.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    internal class Handler : NotificationHandler<test>
    {
        private readonly TextDocumentStore _textDocumentStore;

        public Handler()
        {
        }

        public Handler(TextDocumentStore textDocumentStore)
        {
            _textDocumentStore = textDocumentStore;
        }


        public Task<Unit> Handle(test request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override void Handle(test notification)
        {
            throw new NotImplementedException();
        }
    }

    class test : INotification
    {

    }
}
