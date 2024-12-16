using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{
    public TMP_InputField DefaultFolder;
    public TMP_InputField SelectionColorInput;
    public Image SelectionColor;
    public Toggle TileCircularityX;
    public Toggle TileCircularityY;
    public TMP_InputField BackgroundColorInput;
    public Image BackgroundColor;
    public TMP_InputField EditorPath;
    public TMP_Dropdown Theme;
    public TMP_Dropdown Display;

    public GameObject HighLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        HighLight.SetActive(true);

        DefaultFolder.text = AppManager.settings.defaultPath;
        SelectionColorInput.text = ColorUtility.ToHtmlStringRGB(AppManager.settings.selectionColor);
        SelectionColor.color = AppManager.settings.selectionColor;
        TileCircularityX.isOn = AppManager.settings.xCirc;
        TileCircularityY.isOn = AppManager.settings.yCirc;
        BackgroundColorInput.text = ColorUtility.ToHtmlStringRGB(AppManager.settings.backgroundColor);
        BackgroundColor.color = AppManager.settings.backgroundColor;

        EditorPath.text = AppManager.generalSettings.VScodePath;
        Theme.value = AppManager.generalSettings.theme;
        Display.value = AppManager.generalSettings.fullScreen;
    }

    private void OnDisable()
    {
        AppManager.settings.xCirc = TileCircularityX.isOn;
        AppManager.settings.yCirc = TileCircularityY.isOn;

        AppManager.SaveSettings();

        HighLight.SetActive(false);
    }

    public void SetFolder()
    {
        AppManager.settings.defaultPath = DefaultFolder.text + "/";
    }

    public void BrowseFolder()
    {
        StartCoroutine(BrowseFolderCoroutine());
    }
    IEnumerator BrowseFolderCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Folders, false, null, null, "Select Folder", "Select");

        if (FileBrowser.Success)
        {
            AppManager.settings.defaultPath = FileBrowser.Result[0];
            DefaultFolder.text = FileBrowser.Result[0];
        }
    }

    public void SetVSCodePath()
    {
        AppManager.generalSettings.VScodePath = EditorPath.text + "/";
    }

    public void BrowseVSCodePath()
    {
        StartCoroutine(BrowseVSCodePathCoroutine());
    }
    IEnumerator BrowseVSCodePathCoroutine()
    {
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Executables", ".exe"));
        FileBrowser.SetDefaultFilter(".exe");
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Select Script Editor", "Select");

        if (FileBrowser.Success)
        {
            AppManager.generalSettings.VScodePath = FileBrowser.Result[0];
            EditorPath.text = FileBrowser.Result[0];
        }
    }

    public void SetSelectionColor()
    {
        Color temp;
        ColorUtility.TryParseHtmlString("#" + SelectionColorInput.text, out temp);
        SelectionColor.color = temp;
        AppManager.settings.selectionColor = temp;
    }

    public void SetBackgroundColor()
    {
        Color temp;
        ColorUtility.TryParseHtmlString("#" + BackgroundColorInput.text, out temp);
        BackgroundColor.color = temp;
        AppManager.settings.backgroundColor = temp;
        Camera.main.backgroundColor = temp;
    }

    public void setTheme()
    {
        AppManager.generalSettings.theme = Theme.value;
        GameObject.Find("CreatedContent").GetComponent<SkinManager>().ReSkin();
    }
    public void setDisplay()
    {
        AppManager.generalSettings.fullScreen = Display.value;
        GameObject.Find("CreatedContent").GetComponent<SkinManager>().ReSkin();
    }
}

public class Settings
{
    public string projectName;
    public string defaultPath;
    public Color selectionColor = Color.red;
    public Color backgroundColor = new Color(90.0f/255.0f, 90.0f / 255.0f, 90.0f / 255.0f, 1);
    public bool xCirc = false;
    public bool yCirc = false;
}
