using Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;

public class FileManager : MonoBehaviour
{
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
    }
    private void OnDisable()
    {
        HighLight.SetActive(false);
    }

    public void SaveGame()
    {
        if(File.Exists(AppManager.globalPath + "/Saved/" + AppManager.settings.projectName + ".board"))
            StartCoroutine(SaveGameCoroutine());
        else
            DoSave();
    }

    IEnumerator SaveGameCoroutine()
    {
        yield return DialogBox.ShowDialog("<b>" + AppManager.settings.projectName + "</b> already exists.\nDo you want to replace it?", "Replace", "Cancel");
        if (DialogBox.Result == 0)
        {
            DoSave();
        }
    }

    void DoSave()
    {
        GameObject.Find("Manager").GetComponent<EditorManager>().BoardFinalized();
        string savedJSON = JsonUtility.ToJson(AppManager.saved);

        using (StreamWriter writer = new StreamWriter(AppManager.globalPath + "/Saved/" + AppManager.settings.projectName + ".board"))
        {
            writer.Write(savedJSON);
            writer.Close();
        }

        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
}
