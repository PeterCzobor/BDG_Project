"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.deactivate = exports.activate = exports.extensionContext = void 0;
const net_1 = require("net");
const editorCommands_1 = require("./editorCommands");
const createBdgFile_1 = require("./createBdgFile");
const vscode = require("vscode");
const node_1 = require("vscode-languageclient/node");
let client;
function activate(context) {
    const connectFunc = () => {
        return new Promise((resolve, reject) => {
            function tryConnect() {
                const socket = net_1.connect(`\\\\.\\pipe\\bdgrocks`);
                socket.on("connect", () => {
                    resolve({ writer: socket, reader: socket });
                });
                socket.on("error", (e) => {
                    setTimeout(tryConnect, 5000);
                });
            }
            tryConnect();
            exports.extensionContext = context;
            context.subscriptions.push(editorCommands_1.addPlayer);
            context.subscriptions.push(editorCommands_1.addPiece);
            context.subscriptions.push(editorCommands_1.addDice);
            context.subscriptions.push(createBdgFile_1.createBdgWebview);
        });
    };
    client = new node_1.LanguageClient("bdg", "BDG", connectFunc, {
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
            cancellationStrategy: node_1.CancellationStrategy.Message,
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
exports.activate = activate;
function deactivate() {
    if (!client) {
        return undefined;
    }
    vscode.commands.executeCommand('setContext', 'extensionActivated', false);
    return client.stop();
}
exports.deactivate = deactivate;
//# sourceMappingURL=extension.js.map