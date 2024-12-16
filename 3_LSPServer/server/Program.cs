using System;
using OmniSharp.Extensions.LanguageServer;
using OmniSharp.Extensions.LanguageServer.Server;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using System.IO.Pipes;
using System.IO.Pipelines;
using Nerdbank.Streams;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Immutable;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Newtonsoft.Json.Linq;
using parser;
using System.Collections.Generic;

namespace server
{
    public static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        static BdgDocument bdgDocument = new BdgDocument("...");
        static async Task Main(string[] args)
        {
#if DEBUG
            AllocConsole();
#endif
            while (true)
            {
                var pipeTask = Task.Run(async () =>
                {
                    while (true)
                    {
                        await using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("UnityPipe", PipeDirection.InOut))
                        {
                            await Console.Error.WriteLineAsync("Waiting for Unity to connect on pipe...");
                            await pipeServer.WaitForConnectionAsync();
                            Console.WriteLine("Unity connected!");

                            using (StreamReader reader = new StreamReader(pipeServer))
                            using (StreamWriter writer = new StreamWriter(pipeServer) { AutoFlush = true })
                            {
                                while (true)
                                {
                                    string clientMessage = await reader.ReadLineAsync();

                                    if (clientMessage.Trim().ToLower() == "shutdown")
                                    {
                                        Console.WriteLine("Shutdown message received, closing server.");
                                        Environment.Exit(0);
                                    }
                                    else if(clientMessage != null || clientMessage != string.Empty)
                                    {
                                        Console.WriteLine("Received from Unity: " + clientMessage);

                                        bdgDocument.CheckFile(clientMessage);

                                        List<string> errors = bdgDocument.getErrors();
                                        foreach (var error in errors)
                                        {
                                            await writer.WriteLineAsync(error);
                                        }
                                    }

                                    await writer.WriteLineAsync("END");
                                }
                            }
                        }
                    }
                });

                var languageServerTask = Task.Run(async () =>
                {
                    var (input, output) = await CreateNamedPipeAsync();
                    await Console.Error.WriteLineAsync("Waiting for VSCode to connect on LSP...");
                    var server = await LanguageServer.From(options => ConfigureServer(options, input, output));
                    await Console.Error.WriteLineAsync("VSCode connected!");

                    await Task.WhenAny(
                        Task.Run(async () =>
                        {
                            while (true)
                            {
                                await Task.Delay(1000);
                                if (server.ClientSettings.ProcessId.HasValue &&
                                    Process.GetProcessById((int)server.ClientSettings.ProcessId.Value).HasExited)
                                {
                                    await Console.Error.WriteLineAsync("VSCode disappeared restarting");
                                    server.ForcefulShutdown();
                                    return;
                                }
                            }
                        }),
                        server.WaitForExit
                    );

                    await Console.Error.WriteLineAsync("LSP was shutdown restarting...");
                });

                await Task.WhenAny(pipeTask, languageServerTask);
            }
        }

        public static void ConfigureServer(LanguageServerOptions options, PipeReader input, PipeWriter output)
        {
            options
                .WithInput(input)
                .WithOutput(output)
                .OnJsonNotification("userInputMessage", HandleUserInputMessage)
                .ConfigureLogging(
                    x => x
                        .ClearProviders()
                        .AddLanguageProtocolLogging()
                        .SetMinimumLevel(LogLevel.Debug)
                )
                .WithServices(services =>
                {
                    services
                        .AddSingleton<TextDocumentStore>()
                        .AddSingleton<CompletionProvider>()
                        .AddSingleton<SignatureHelpProvider>()
                        .AddSingleton<HoverProvider>()
                        .AddSingleton<TokenProvider>()
                        .AddSingleton<CodeActionProvider>()
                        .AddSingleton<OutlineProvider>()
                        .ConfigureSection<IniConfiguration>("bdg")
                        ;
                })
                .WithConfigurationSection("bdg")
                .OnInitialized((instance, client, server, ct) =>
                {
                    if (server?.Capabilities?.CodeActionProvider?.Value?.CodeActionKinds != null)
                    {
                        server.Capabilities.CodeActionProvider.Value.CodeActionKinds = server.Capabilities.CodeActionProvider.Value.CodeActionKinds.ToImmutableArray().Remove(CodeActionKind.Empty).ToArray();
                    }
                    return Task.CompletedTask;
                });
        }

        private static void HandleUserInputMessage(JToken token1, CancellationToken token2)
        {
            var message = token1?["message"]?.ToString();

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine($"Received message from client: {message}");
            }
        }

        private static async Task<(PipeReader input, PipeWriter output)> CreateNamedPipeAsync()
        {
            var pipe = new NamedPipeServerStream(
                            pipeName: @"bdgrocks",
                            direction: PipeDirection.InOut,
                            maxNumberOfServerInstances: 1,
                            transmissionMode: PipeTransmissionMode.Byte,
                            options: System.IO.Pipes.PipeOptions.Asynchronous);
            await pipe.WaitForConnectionAsync();
            var pipeline = pipe.UsePipe();
            return (pipeline.Input, pipeline.Output);
        }
#nullable enable
        public static IServiceCollection ConfigureSection<TOptions>(this IServiceCollection services, string? sectionName)
            where TOptions : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions()
                .AddSingleton<IOptionsChangeTokenSource<TOptions>>(
                _ => new ConfigurationChangeTokenSource<TOptions>(
                    Options.DefaultName,
                    sectionName == null ? _.GetRequiredService<IConfiguration>() : _.GetRequiredService<IConfiguration>().GetSection(sectionName)
                )
            );
            return services.AddSingleton<IConfigureOptions<TOptions>>(
                _ => new NamedConfigureFromConfigurationOptions<TOptions>(
                    Options.DefaultName,
                    sectionName == null ? _.GetRequiredService<IConfiguration>() : _.GetRequiredService<IConfiguration>().GetSection(sectionName)
                )
            );
        }
#nullable disable
    }
}
