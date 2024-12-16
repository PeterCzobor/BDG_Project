using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AppManager : MonoBehaviour
{
    static bool created = false;

    public static SaveJSON saved = new SaveJSON();

    public static Settings settings = new Settings();

    public static SettingsJSON generalSettings = new SettingsJSON();

    public static string visitorBackUp;

    public Material tileTexture;

    public static string globalPath = "";

    void Awake()
    {
#if UNITY_EDITOR
        globalPath = @"C:\Users\czobo\Desktop\boardgame\";
#else
        globalPath = AppDomain.CurrentDomain.BaseDirectory;
#endif

        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        LoadSettings();
        GetComponent<SkinManager>().ReSkin();
    }
        // Start is called before the first frame update
    void Start()
    {
        settings.defaultPath = Application.persistentDataPath + "/";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public enum SceneType
    {
        StartScene = 0,
        BoardEditor = 1,
        GameScene = 2
    }
    public static string currentScene = "StartScene";
    public static void ChangeScene(string scene)
    {
        switch (scene)
        {
            case "StartScene":
                saved = new SaveJSON();
                break;
            case "BoardEditor":
                break;
            case "GameScene":
                if(currentScene == "BoardEditor")
                {
                    GameManager.debugMode = true;
                }
                else
                GameManager.debugMode = false;
                break;
        }
        currentScene = scene;
        SceneManager.LoadSceneAsync(scene);
    }

    private void OnApplicationQuit()
    {
        PipeClient.ShutDown();
    }
    public static void LoadSettings()
    {
        using (StreamReader reader = new StreamReader(globalPath + "/settings.json"))
        {
            generalSettings = JsonUtility.FromJson<SettingsJSON>(reader.ReadToEnd());
        }
    }
    public static void SaveSettings()
    {
        string savedJSON = JsonUtility.ToJson(generalSettings);
        using (StreamWriter writer = new StreamWriter(globalPath + "/settings.json"))
        {
            writer.Write(savedJSON);
        }
    }

    [Serializable]
    public class SettingsJSON
    {
        public string VScodePath = "";
        public int theme = 0;
        public int fullScreen = 0;

        public override string ToString()
        {
            return $"VScodePath={VScodePath}, theme={theme}, fullScreen={fullScreen}";
        }
        public SettingsJSON(){}
        public SettingsJSON(string VScodePath, int theme, int fullScreen)
        {
            this.VScodePath = VScodePath;
            this.theme = theme;
            this.fullScreen = fullScreen;
        }
    }
}
