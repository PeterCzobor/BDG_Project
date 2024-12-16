"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.addDice = exports.addPiece = exports.addPlayer = void 0;
const vscode = require("vscode");
const vscode_1 = require("vscode");
exports.addPlayer = vscode.commands.registerCommand('extension.addPlayer', () => __awaiter(void 0, void 0, void 0, function* () {
    const editor = vscode.window.activeTextEditor;
    if (!editor) {
        vscode.window.showErrorMessage("No active text editor");
        return;
    }
    const playerName = yield vscode.window.showInputBox({
        placeHolder: 'Name',
        prompt: 'Enter the name of the Player',
    });
    if (!playerName) {
        vscode.window.showErrorMessage('No player name entered');
        return;
    }
    const cursorPosition = editor.selection.active;
    const edit = new vscode.WorkspaceEdit();
    const newText = 'Player player_' + playerName + '("' + playerName + '");';
    edit.insert(editor.document.uri, cursorPosition, newText);
    const newText1 = 'player_' + playerName + '.WinCondition()\n{\n\tOUT = false;\n}';
    edit.insert(editor.document.uri, new vscode_1.Position(editor.document.lineCount + 1, 0), newText1);
    vscode.workspace.applyEdit(edit);
}));
exports.addPiece = vscode.commands.registerCommand('extension.addPiece', () => __awaiter(void 0, void 0, void 0, function* () {
    const editor = vscode.window.activeTextEditor;
    if (!editor) {
        vscode.window.showErrorMessage("No active text editor");
        return;
    }
    const playerKey = yield vscode.window.showInputBox({
        placeHolder: 'PlayerKey',
        prompt: 'Enter the key of the Player it will be assigned to',
    });
    if (!playerKey) {
        vscode.window.showErrorMessage('No player key entered');
        return;
    }
    const posx = yield vscode.window.showInputBox({
        placeHolder: 'PositionX',
        prompt: 'Enter the X coordinate of the starting position',
        validateInput: text => {
            if (isNaN(Number(text))) {
                return 'X coordinate must be a number!';
            }
        }
    });
    if (!posx) {
        vscode.window.showErrorMessage('No X coordinate entered');
        return;
    }
    const posy = yield vscode.window.showInputBox({
        placeHolder: 'PositionY',
        prompt: 'Enter the X coordinate of the starting position',
        validateInput: text => {
            if (isNaN(Number(text))) {
                return 'Y coordinate must be a number!';
            }
        }
    });
    if (!posy) {
        vscode.window.showErrorMessage('No X coordinate entered');
        return;
    }
    const cursorPosition = editor.selection.active;
    const edit = new vscode.WorkspaceEdit();
    const newText = 'Piece piece(' + playerKey + ', ' + posx + ', ' + posy + ');';
    edit.insert(editor.document.uri, cursorPosition, newText);
    vscode.workspace.applyEdit(edit);
}));
exports.addDice = vscode.commands.registerCommand('extension.addDice', () => __awaiter(void 0, void 0, void 0, function* () {
    const editor = vscode.window.activeTextEditor;
    if (!editor) {
        vscode.window.showErrorMessage("No active text editor");
        return;
    }
    const diceValues = yield vscode.window.showInputBox({
        placeHolder: 'Value1 Value2 ...',
        prompt: 'Enter the possible values of the Dice',
        validateInput: text => {
            const numberList = text.split(' ');
            if (numberList.some(number => isNaN(Number(number)))) {
                return 'Invalid number entered';
            }
        }
    });
    if (!diceValues) {
        vscode.window.showErrorMessage('No player name entered');
        return;
    }
    const cursorPosition = editor.selection.active;
    const edit = new vscode.WorkspaceEdit();
    const newText = 'Dice dice(' + diceValues.trimEnd().replace(/ /g, ", ") + ');';
    edit.insert(editor.document.uri, cursorPosition, newText);
    vscode.workspace.applyEdit(edit);
}));
//# sourceMappingURL=editorCommands.js.map