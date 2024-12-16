using Language;
using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class CommandHandler : MonoBehaviour
{
    CommandManager commandManager;

    public Button redoButton;
    public Button undoButton;

    void Start()
    {
        commandManager = new CommandManager();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
        {
            Undo();
        }
        if (Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.LeftControl))
        {
            Redo();
        }

        if (commandManager.UndoStackCount() == 0)
        {
            undoButton.interactable = false;
            Color temp = undoButton.transform.GetChild(0).GetComponent<Image>().color;
            temp.a = 0.4f;
            undoButton.transform.GetChild(0).GetComponent<Image>().color = temp;
        }
        else
        {
            undoButton.interactable = true;
            Color temp = undoButton.transform.GetChild(0).GetComponent<Image>().color;
            temp.a = 1.0f;
            undoButton.transform.GetChild(0).GetComponent<Image>().color = temp;
        }
        if (commandManager.RedoStackCount() == 0)
        {
            redoButton.interactable = false;
            Color temp = redoButton.transform.GetChild(0).GetComponent<Image>().color;
            temp.a = 0.4f;
            redoButton.transform.GetChild(0).GetComponent<Image>().color = temp;
        }
        else
        {
            redoButton.interactable = true;
            Color temp = redoButton.transform.GetChild(0).GetComponent<Image>().color;
            temp.a = 1.0f;
            redoButton.transform.GetChild(0).GetComponent<Image>().color = temp;
        }

    }

    public void Undo()
    {
        commandManager.Undo();
    }
    public void Redo()
    {
        commandManager.Redo();
    }
}
public interface ICommand
{
    void Execute();
    void Undo();
    bool IsValid();
}

public class TileColorCommand : ICommand
{
    List<TileObject> tileObjects = new List<TileObject>();
    Color newColor;
    List<Color> prevColors = new List<Color>();

    bool valid;

    public TileColorCommand(List<TileObject> _tileObjects, Color _newColor)
    {
        valid = true;
        if (_tileObjects[0].color != _newColor)
        {
            foreach (var item in _tileObjects)
                tileObjects.Add(item);
            newColor = _newColor;
            foreach (var item in tileObjects)
                prevColors.Add(item.color);
        }
        else
        {
            valid = false;
        }
    }

    public void Execute()
    {
        foreach(var item in tileObjects)
        {
            item.color = newColor;
            item.GetComponent<MeshRenderer>().material.color = newColor;
        }
    }

    public void Undo()
    {
        for(int i = 0; i< tileObjects.Count; i++)
        {
            tileObjects[i].color = prevColors[i];
            tileObjects[i].GetComponent<MeshRenderer>().material.color = prevColors[i];
        }
    }

    public bool IsValid()
    {
        return valid;
    }
}

public class TileTextureCommand : ICommand
{
    List<TileObject> tileObjects = new List<TileObject>();
    string newPath;
    List<string> prevPaths = new List<string>();

    bool valid;

    public TileTextureCommand(List<TileObject> _tileObjects, string _newPath)
    {
        valid = true;
        if (_tileObjects[0].texture != _newPath)
        {
            foreach (var item in _tileObjects)
                tileObjects.Add(item);
            newPath = _newPath;
            foreach (var item in tileObjects)
                prevPaths.Add(item.texture);
        }
        else
        {
            valid = false;
        }
    }

    public void Execute()
    {
        byte[] fileData = Convert.FromBase64String(newPath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);

        foreach (var item in tileObjects)
        {
            item.texture = Convert.ToBase64String(fileData);
            item.GetComponent<MeshRenderer>().material.mainTexture = texture;
        }
    }

    public void Undo()
    {
        for (int i = 0; i < tileObjects.Count; i++)
        {
            Texture2D texture;
            if (prevPaths[i] == "")
            {
                texture = (Texture2D)GameObject.Find("CreatedContent").GetComponent<AppManager>().tileTexture.mainTexture;
            }
            else
            {
                byte[] fileData = Convert.FromBase64String(prevPaths[i]);
                texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);
            }

            tileObjects[i].texture = prevPaths[i];
            tileObjects[i].GetComponent<MeshRenderer>().material.mainTexture = texture;
        }
    }

    public bool IsValid()
    {
        return valid;
    }
}

public class TileDeleteCommand : ICommand
{
    List<TileJSON> tileJSONs = new List<TileJSON>();
    List<TileObject> tileObjects = new List<TileObject>();

    public TileDeleteCommand(List<TileObject> _tileObjects)
    {
        tileObjects = _tileObjects;
        foreach (var item in tileObjects)
        {
            tileJSONs.Add(SaveLoad.SaveTile(item));
        }
    }

    public void Execute()
    {
        EditorManager.DeleteTile(tileObjects);
    }

    public void Undo()
    {
        foreach (var item in tileJSONs)
        {
            TileObject TO = EditorManager.redoDeleteTile();
            SaveLoad.LoadTile(TO, item);
            TO.CopyElement(TO);
            tileObjects.Add(TO);
        }
    }

    public bool IsValid()
    {
        return true;
    }
}

public class CommandManager
{
    static Stack<ICommand> undoStack = new Stack<ICommand>();
    static Stack<ICommand> redoStack = new Stack<ICommand>();

    public static void ExecuteCommand(ICommand command)
    {
        if (command.IsValid())
        {
            command.Execute();
            undoStack.Push(command);
            redoStack.Clear(); // Clear redo stack because new command invalidates redo history
        }
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
        }
    }

    public int UndoStackCount()
    { return undoStack.Count; }

    public int RedoStackCount()
    { return redoStack.Count; }
}