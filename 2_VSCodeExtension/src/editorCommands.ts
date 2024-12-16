import * as vscode from 'vscode';
import { Position } from "vscode";

export const addPlayer = vscode.commands.registerCommand('extension.addPlayer', async () => {

  const editor = vscode.window.activeTextEditor;
  if (!editor) {
    vscode.window.showErrorMessage("No active text editor");
    return;
  }

  const playerName = await vscode.window.showInputBox({
    placeHolder: 'Name',
    prompt: 'Enter the name of the Player',
  });
  if(!playerName)
  {
    vscode.window.showErrorMessage('No player name entered');
    return;
  }

  const cursorPosition = editor.selection.active;
  const edit = new vscode.WorkspaceEdit();
  const newText = 'Player player_'+playerName+'("'+playerName+'");';
  edit.insert(editor.document.uri, cursorPosition, newText);
  const newText1 = 'player_' + playerName + '.WinCondition()\n{\n\tOUT = false;\n}';
  edit.insert(editor.document.uri, new Position(editor.document.lineCount+1, 0), newText1);
  vscode.workspace.applyEdit(edit);

});

export const addPiece = vscode.commands.registerCommand('extension.addPiece', async () => {

  const editor = vscode.window.activeTextEditor;
  if (!editor) {
    vscode.window.showErrorMessage("No active text editor");
    return;
  }

  const playerKey = await vscode.window.showInputBox({
    placeHolder: 'PlayerKey',
    prompt: 'Enter the key of the Player it will be assigned to',
  });
  if(!playerKey)
  {
    vscode.window.showErrorMessage('No player key entered');
    return;
  }
  const posx = await vscode.window.showInputBox({
    placeHolder: 'PositionX',
    prompt: 'Enter the X coordinate of the starting position',
    validateInput: text=>{
      if(isNaN(Number(text)))
      {
        return 'X coordinate must be a number!';
      }
    }
  });
  if(!posx)
  {
    vscode.window.showErrorMessage('No X coordinate entered');
    return;
  }
  const posy = await vscode.window.showInputBox({
    placeHolder: 'PositionY',
    prompt: 'Enter the X coordinate of the starting position',
    validateInput: text=>{
      if(isNaN(Number(text)))
      {
        return 'Y coordinate must be a number!';
      }
    }
  });
  if(!posy)
  {
    vscode.window.showErrorMessage('No X coordinate entered');
    return;
  }

  const cursorPosition = editor.selection.active;
  const edit = new vscode.WorkspaceEdit();
  const newText = 'Piece piece('+playerKey+', '+posx+', '+posy+');';
  edit.insert(editor.document.uri, cursorPosition, newText);
  vscode.workspace.applyEdit(edit);
});

export const addDice = vscode.commands.registerCommand('extension.addDice', async () => {

  const editor = vscode.window.activeTextEditor;
  if (!editor) {
    vscode.window.showErrorMessage("No active text editor");
    return;
  }

  const diceValues = await vscode.window.showInputBox({
    placeHolder: 'Value1 Value2 ...',
    prompt: 'Enter the possible values of the Dice',
    validateInput: text=>{
      const numberList = text.split(' ');
        if (numberList.some(number => isNaN(Number(number)))) {
          return 'Invalid number entered';
        }
    }
  });
  if(!diceValues)
  {
    vscode.window.showErrorMessage('No player name entered');
    return;
  }

  const cursorPosition = editor.selection.active;
  const edit = new vscode.WorkspaceEdit();
  const newText = 'Dice dice('+diceValues.trimEnd().replace(/ /g, ", ")+');';
  edit.insert(editor.document.uri, cursorPosition, newText);
  vscode.workspace.applyEdit(edit);
});