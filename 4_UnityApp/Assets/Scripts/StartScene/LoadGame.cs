using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
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
        foreach (GameObject go in loadables)
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

    public void Load(GameObject loadable)
    {
        StreamReader reader = new StreamReader(AppManager.globalPath + "/Saved/" + loadable.transform.GetChild(0).GetComponent<TMP_Text>().text + ".board");
        AppManager.saved = JsonUtility.FromJson<SaveJSON>(reader.ReadToEnd());

        reader.Close();

        SaveLoad.LoadSettings(AppManager.settings, AppManager.saved.settings);

        AppManager.visitorBackUp = null;

        AppManager.ChangeScene("GameScene");
    }

}
