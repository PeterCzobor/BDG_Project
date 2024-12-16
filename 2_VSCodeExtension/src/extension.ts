import { connect } from "net";
import { ExtensionContext } from "vscode";
import { addPlayer, addPiece, addDice } from "./editorCommands";
import { createBdgWebview } from "./createBdgFile";
import * as vscode from 'vscode';

import {
  LanguageClient,
  LanguageClientOptions,
  ServerOptions,
  StreamInfo,
  TransportKind,
  CancellationReceiverStrategy,
  CancellationStrategy,
} from "vscode-languageclient/node";
import internal = require("stream");

let client: LanguageClient;
export let extensionContext: ExtensionContext;

export function activate(context: ExtensionContext) {
  const connectFunc = () => {
    return new Promise<StreamInfo>((resolve, reject) => {
      function tryConnect() {
        const socket = connect(`\\\\.\\pipe\\bdgrocks`);
        socket.on("connect", () => {
          resolve({ writer: socket, reader: socket });
        });
        socket.on("error", (e) => {
          setTimeout(tryConnect, 5000);
        });
      }
      tryConnect();
      extensionContext = context;
      context.subscriptions.push(addPlayer);
      context.subscriptions.push(addPiece);
      context.subscriptions.push(addDice);
      context.subscriptions.push(createBdgWebview);
    });
  };


  client = new LanguageClient("bdg", "BDG", connectFunc, {
    documentSelector: [
      {
        language: "bdg",
      },
      {
        pattern: "**/*.bdg",
      },
    ],

    progressOnInitialization: true,
    connectionOptions: {
      maxRestartCount: 10,
      cancellationStrategy: CancellationStrategy.Message,
    },
    synchronize: {
      // Synchronize the setting section 'languageServerExample' to the server
      // configurationSection: "languageServerExample",
      // fileEvents: workspace.createFileSystemWatcher("**/*.cs"),
    },
  });
  client.registerProposedFeatures();
  client.start();
  vscode.commands.executeCommand('setContext', 'extensionActivated', true);
}

export function deactivate(): Thenable<void> | undefined {
  if (!client) {
    return undefined;
  }
  vscode.commands.executeCommand('setContext', 'extensionActivated', false);
  return client.stop();
}
