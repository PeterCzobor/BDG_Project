"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.createBdgWebview = void 0;
const vscode = require("vscode");
const vscode_1 = require("vscode");
const extension_1 = require("./extension");
const path = require("path");
const fs = require("fs");
let folderPath;
if (!vscode.workspace.workspaceFolders) {
    folderPath = "";
}
else {
    let root;
    if (vscode.workspace.workspaceFolders.length === 1) {
        root = vscode.workspace.workspaceFolders[0];
    }
    else {
        const editor = vscode.window.activeTextEditor;
        if (editor) {
            root = vscode_1.workspace.getWorkspaceFolder(editor.document.uri);
        }
    }
    if (root) {
        folderPath = root.uri.fsPath;
    }
}
exports.createBdgWebview = vscode.commands.registerCommand('extension.newBdgFile', () => {
    const panel = vscode.window.createWebviewPanel('createFile', 'Create New BDG File', vscode.ViewColumn.One, { enableScripts: true });
    const pathToHtml = vscode.Uri.file(path.join(extension_1.extensionContext.extensionPath, 'html', 'CreateFile.html'));
    const pathUri = pathToHtml.with({ scheme: 'vscode-resource' });
    panel.webview.html = fs.readFileSync(pathUri.fsPath, 'utf8');
    panel.webview.onDidReceiveMessage(message => {
        switch (message.command) {
            case 'createFile':
                if (message.fileName && folderPath.length > 0) {
                    const filePath = folderPath + '/' + message.fileName + '.bdg';
                    fs.writeFile(filePath, getScriptByTemplate(message.template, message.playerNumber, message.diceValues), err => {
                        if (err) {
                            vscode.window.showErrorMessage(`Failed to create file: ${err.message}`);
                        }
                        else {
                            vscode.window.showInformationMessage(`File '${message.fileName}' created successfully`);
                            vscode.workspace.openTextDocument(filePath).then(document => {
                                vscode.window.showTextDocument(document);
                            });
                            panel.dispose();
                        }
                    });
                }
                break;
        }
    });
});
function getScriptByTemplate(template, numOfPlayer, diceValues) {
    let newText = "";
    switch (template) {
        case "Blank":
            break;
        case "AbstractStrategyGame":
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'Player player' + i + '("Player' + i + '");\n\n';
                newText += 'Piece piece' + i + '(player' + i + ', 0, 0);\n\n';
                newText += 'player' + i + '.Turn(<SelectPiece(piece)>, <SelectTile(tile)>, <piece.Rule(tile)>);\n\n';
                newText += '\n';
            }
            newText += '\n\n';
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'piece' + i + '.Rule(Tile t)\n{\n\tOUT = false;\n}\n\n';
            }
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'player' + i + '.WinCondition()\n{\n\tOUT = false;\n}\n\n';
            }
            break;
        case "WorkerPlacementGame":
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'Player player' + i + '("Player' + i + '");\n\n';
                newText += 'player' + i + '.Turn(<SelectTile(tile)>, <player.Rule(tile)>);\n\n';
                newText += '\n';
            }
            newText += '\n\n';
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'player' + i + '.Rule(Tile t)\n{\n\tOUT = false;\n}\n\n';
            }
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'player' + i + '.WinCondition()\n{\n\tOUT = false;\n}\n\n';
            }
            break;
        case "RollAndMoveGame":
            newText += 'Dice dice(' + diceValues.trimEnd().replace(/ /g, ", ") + ');\n\n';
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'Player player' + i + '("Player' + i + '");\n\n';
                newText += 'Piece piece' + i + '(player' + i + ', 0, 0);\n';
                newText += 'piece' + i + '.Route = [(0,0), (0,1), (0,2)];\n\n';
                newText += 'player' + i + '.Turn(<dice.Roll()>, <SelectPiece(piece)>, <piece.Rule()>);\n\n';
                newText += '\n';
            }
            newText += '\n\n';
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'piece' + i + '.Rule()\n{\n\tOUT = false;\n}\n\n';
            }
            for (let i = 1; i <= numOfPlayer; i++) {
                newText += 'player' + i + '.WinCondition()\n{\n\tOUT = false;\n}\n\n';
            }
            break;
    }
    return newText;
}
//# sourceMappingURL=createBdgFile.js.map