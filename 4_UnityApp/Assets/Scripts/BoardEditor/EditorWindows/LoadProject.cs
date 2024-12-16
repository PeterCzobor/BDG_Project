using Language;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class LoadProject : MonoBehaviour
{
    public GameObject loadableTemplate;
    public List<GameObject> loadables = new List<GameObject>();

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
        CameraManager.SetCamera(false);

        foreach(GameObject go in loadables)
        {
            Destroy(go);
        }
        loadables.Clear();
        DirectoryInfo d = new DirectoryInfo(AppManager.globalPath + "/Saved/");
        foreach (var file in d.GetFiles("*.board").OrderByDescending(p => p.LastAccessTimeUtc).ToArray())
        {
            GameObject temp = Instantiate(loadableTemplate, loadableTemplate.transform.parent);
            temp.SetActive(true);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (loadables.Count + 1) * -40, 0);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = file.Name.Replace(file.Extension, "");
            temp.transform.GetChild(1).GetComponent<TMP_Text>().text = file.LastAccessTime.ToString("yyyy. MM. dd.");
            loadables.Add(temp);
        }
    }

    private void OnDisable()
    {
        CameraManager.SetCamera(true);
    }
    public static void CreateBoard()
    {
        GameObject.Find("Manager").GetComponent<EditorManager>().ClearBoard();

        for (int i = 0; i < AppManager.saved.tiles.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("Tile"));
            SaveLoad.LoadTile(temp.GetComponent<TileObject>(), AppManager.saved.tiles[i]);
            temp.GetComponent<TileObject>().CopyElement(temp.GetComponent<TileObject>());
            EditorManager.tileObjects.Add(temp.GetComponent<TileObject>());
        }
        for (int i = 0; i < AppManager.saved.buttons.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("ButtonTemplate"), GameObject.Find("Canvas").transform);
            temp.transform.SetAsFirstSibling();
            SaveLoad.LoadButton(temp.GetComponent<ButtonObject>(), AppManager.saved.buttons[i]);
            temp.GetComponent<ButtonObject>().CopyElement(temp.GetComponent<ButtonObject>());
            temp.name = temp.GetComponent<ButtonObject>().buttonKey;
            EditorManager.uiObjects.Add(temp.GetComponent<ButtonObject>());
        }
        for (int i = 0; i < AppManager.saved.labels.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("LabelTemplate"), GameObject.Find("Canvas").transform);
            temp.transform.SetAsFirstSibling();
            SaveLoad.LoadLabel(temp.GetComponent<LabelObject>(), AppManager.saved.labels[i]);
            temp.GetComponent<LabelObject>().CopyElement(temp.GetComponent<LabelObject>());
            temp.name = temp.GetComponent<LabelObject>().labelKey;
            EditorManager.uiObjects.Add(temp.GetComponent<LabelObject>());
        }
        for (int i = 0; i < AppManager.saved.images.Count; i++)
        {
            GameObject temp = Instantiate(GameObject.Find("ImageTemplate"));
            SaveLoad.LoadImage(temp.GetComponent<ImageObject>(), AppManager.saved.images[i]);
            temp.GetComponent<ImageObject>().CopyElement(temp.GetComponent<ImageObject>());
            temp.name = temp.GetComponent<ImageObject>().ID;
            EditorManager.imageObjects.Add(temp.GetComponent<ImageObject>());
        }
        EditorManager.assets = AppManager.saved.assets;

        EditorManager.CreateImageButtons();

        EditorManager.Script = AppManager.saved.script;

        GameObject.Find("Manager").GetComponent<EditorManager>().EnableButtons(true);

        Camera.main.GetComponent<CameraManager>().enabled = false;
        Camera.main.GetComponent<CameraManager>().enabled = true;
    }

    public void LoadGame(GameObject loadable)
    {
        LoadGame(AppManager.globalPath + "/Saved/" + loadable.transform.GetChild(0).GetComponent<TMP_Text>().text + ".board");

        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }

    public static void LoadGame(string path)
    {
        if(path != "")
        {
            using (StreamReader sr = new StreamReader(path))
            {
                AppManager.saved = JsonUtility.FromJson<SaveJSON>(sr.ReadToEnd());
            }
        }

        SaveLoad.LoadSettings(AppManager.settings, AppManager.saved.settings);

        CreateBoard();

        GameObject.Find("Name").GetComponent<TMP_InputField>().text = AppManager.settings.projectName;
    }

    GameObject subject;
    public void DeleteProject(GameObject gameObject)
    {
        subject = gameObject;
        StartCoroutine(DeleteProjectCoroutine());
    }

    IEnumerator DeleteProjectCoroutine()
    {
        yield return DialogBox.ShowDialog("<b>Do you want to delete this project?</b>", "Delete", "Cancel");
        if (DialogBox.Result == 0)
        {
            File.Delete(AppManager.globalPath + "/Saved/" + subject.transform.GetChild(0).GetComponent<TMP_Text>().text + ".board");
            subject = null;
            OnEnable();
        }
        else
        {
            subject = null;
        }
    }
}
