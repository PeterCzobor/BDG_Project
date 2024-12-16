using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    void Start()
    {
        StartServer();

        string path = "";
#if UNITY_EDITOR
        path = @"C:\Users\czobo\Desktop\boardgame\";
#else
        path = AppDomain.CurrentDomain.BaseDirectory;
#endif
        if (File.Exists(path + "temp.board"))
        {
            File.Delete(path + "temp.board");
        }
        
        /*SaveJSON temp = new SaveJSON();
        string jsonPath = "C:\\Users\\czobo\\AppData\\LocalLow\\DefaultCompany\\BoardGame\\Saved\\Chess.board";
        using (StreamReader sr = new StreamReader(jsonPath))
        {
            temp = ConvertImage(JsonUtility.FromJson<SaveJSON>(sr.ReadToEnd()));
        }
        using (StreamWriter writer = new StreamWriter(jsonPath))
        {
            writer.Write(JsonUtility.ToJson(temp));
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    SaveJSON ConvertImage(SaveJSON json)
    {
        foreach (TileJSON item in json.tiles)
        {
            if (File.Exists(json.settings.defaultPath + item.texture))
            {
                byte[] imageBytes = File.ReadAllBytes(json.settings.defaultPath + item.texture);
                item.texture = Convert.ToBase64String(imageBytes);
            }
            foreach (SideJSON ts in item.sides)
            {
                if (File.Exists(json.settings.defaultPath + ts.textureS))
                {
                    byte[] imageBytes = File.ReadAllBytes(json.settings.defaultPath + ts.textureS);
                    ts.textureS = Convert.ToBase64String(imageBytes);
                }
            }
        }
        foreach (ButtonJSON item in json.buttons)
        {
            if (File.Exists(json.settings.defaultPath + item.texture))
            {
                byte[] imageBytes = File.ReadAllBytes(json.settings.defaultPath + item.texture);
                item.texture = Convert.ToBase64String(imageBytes);
            }
        }
        foreach (ImageJSON item in json.images)
        {
            if (File.Exists(json.settings.defaultPath + item.texture))
            {
                byte[] imageBytes = File.ReadAllBytes(json.settings.defaultPath + item.texture);
                item.texture = Convert.ToBase64String(imageBytes);
            }
        }
        foreach (AssetJSON item in json.assets)
        {
            if (File.Exists(item.path))
            {
                byte[] imageBytes = File.ReadAllBytes(item.path);
                item.path = Convert.ToBase64String(imageBytes);
            }
        }
        return json;
    }
    void StartServer()
    {
        PipeClient.StartClient();
    }

    public void Editor()
    {
        AppManager.ChangeScene("BoardEditor");
    }

    public void Exit()
    {
        StartCoroutine(ExitAppCoroutine());
    }

    IEnumerator ExitAppCoroutine()
    {
        yield return DialogBox.ShowDialog("<b>Are you sure you want to exit?</b>", "Yes", "No");
        if (DialogBox.Result == 0)
        {
            PipeClient.ShutDown();
            Application.Quit();
        }
    }

}
