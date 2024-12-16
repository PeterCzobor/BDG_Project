using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using TMPro;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour
{
    public GameObject loadableTemplate;
    public List<GameObject> loadables = new List<GameObject>();

    public GameManager manager;

    bool save;
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

    }
    private void OnDisable()
    {
        CameraManager.SetCamera(true);
    }

    public void LoadGame(GameObject loadable)
    {
        if(save)
        {
            saveName.text = loadable.transform.GetChild(0).GetComponent<TMP_Text>().text;
            return;
        }

        StreamReader reader = new StreamReader(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName + "/" + loadable.transform.GetChild(0).GetComponent<TMP_Text>().text + ".board");

        string data = reader.ReadToEnd();
        string[] elements = data.Split(new string[] { "*%%%%*" }, StringSplitOptions.RemoveEmptyEntries);

        AppManager.saved = JsonUtility.FromJson<SaveJSON>(elements[0]);
        AppManager.visitorBackUp = elements[1];

        reader.Close();

        SaveLoad.LoadSettings(AppManager.settings, AppManager.saved.settings);

        manager.enabled = false;
        manager.enabled = true;
        gameObject.SetActive(false);
    }

    GameObject subject;
    public GameObject DeletePanel;
    public void DeleteProject(GameObject gameObject)
    {
        subject = gameObject;
        DeletePanel.SetActive(true);
    }
    public void DoDelete()
    {
        File.Delete(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName + "/" + subject.transform.GetChild(0).GetComponent<TMP_Text>().text + ".board");
        DeletePanel.SetActive(false);
        subject = null;
        SaveOrLoad(save);
    }
    public void CancelDelete()
    {
        DeletePanel.SetActive(false);
        subject = null;
    }

    public TMP_InputField saveName;
    public void SaveGame()
    {
        string savedJSON = JsonUtility.ToJson(AppManager.saved);

        using (StreamWriter writer = new StreamWriter(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName + "/" + saveName.text + ".board"))
                {
            writer.Write(savedJSON);
            writer.Write("*%%%%*");
            writer.Write(AppManager.visitorBackUp);
            writer.Close();
        }
        gameObject.SetActive(false);
    }

    public void SaveOrLoad(bool save)
    {
        this.save = save;

        CameraManager.SetCamera(false);

        if (save)
        {
            saveName.gameObject.SetActive(true);
            saveName.text = "";
            transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>().text = "Save Game";
        }
        else
        {
            saveName.gameObject.SetActive(false);
            transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>().text = "Load Game";
        }

        foreach (GameObject go in loadables)
        {
            Destroy(go);
        }
        loadables.Clear();

        if (!Directory.Exists(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName))
            Directory.CreateDirectory(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName);
        DirectoryInfo d = new DirectoryInfo(AppManager.globalPath + "/SavedGames/" + AppManager.settings.projectName);
        foreach (var file in d.GetFiles("*.board").OrderByDescending(p => p.LastAccessTimeUtc).ToArray())
        {
            GameObject temp = Instantiate(loadableTemplate, loadableTemplate.transform.parent);
            temp.SetActive(true);
            if (save)
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -60 + (loadables.Count + 1) * -40, 0);
            else
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (loadables.Count + 1) * -40, 0);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = file.Name.Replace(file.Extension, "");
            temp.transform.GetChild(1).GetComponent<TMP_Text>().text = file.LastAccessTime.ToString("yyyy. MM. dd.");
            loadables.Add(temp);
        }
    }
}
