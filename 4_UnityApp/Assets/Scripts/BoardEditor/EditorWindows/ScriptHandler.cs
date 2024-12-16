using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScriptHandler : MonoBehaviour
{
    public GameObject HighLight;

    public GameObject VsCodePathPicker;

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
    }
    private void OnDisable()
    {
        HighLight.SetActive(false);
    }

    public void PrepareScript()
    {
        if (File.Exists(AppManager.generalSettings.VScodePath))
        {
            OpenVsCode();
        }
        else
        {
            VsCodePathPicker.SetActive(true);
        }
    }

    public void OpenVsCode()
    {
        string filePath = Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg");
        Process.Start(AppManager.generalSettings.VScodePath, filePath);
    }

    public void PickVsCodePath(TMP_InputField inputPath)
    {
        AppManager.generalSettings.VScodePath = inputPath.text;
        AppManager.SaveSettings();
        OpenVsCode();
    }
}
