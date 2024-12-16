using Antlr4.Runtime;
using Assets.Language;
using Language;
using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VariablesManager : MonoBehaviour
{
    public GameObject rowTemplate;
    public GameObject AddButton;
    public GameObject TableBody;
    public List<GameObject> rows = new List<GameObject>();

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

        foreach (GameObject row in rows)
        {
            Destroy(row);
        }
        rows.Clear();

        string script = "";
        if (File.Exists(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg")))
        {
            StreamReader reader = new StreamReader(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg"));
            script = reader.ReadToEnd();
            reader.Close();
        }
        Visitor visitor = new Visitor();
        var lexer = new Combined1Lexer(new AntlrInputStream(script));
        var tokens = new CommonTokenStream(lexer);
        var parser = new Combined1Parser(tokens);
        var tree = parser.program();
        visitor.Visit(tree);

        AddButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -180, 0);
        foreach (var kvp in visitor.Variables)
        {
            if(kvp.Value is ComplexVar)
                AddAsset(kvp);
        }
    }
    private void OnDisable()
    {
        EditorManager.assets.Clear();

        foreach (GameObject row in rows)
        {
            //EditorManager.assets[row.transform.GetChild(0).GetComponent<TMP_InputField>().text] = row.transform.GetChild(1).GetComponent<TMP_InputField>().text;
        }

        CameraManager.SetCamera(true);
    }

    void AddAsset(KeyValuePair<string, object> kvp)
    {
        GameObject temp = Instantiate(rowTemplate, rowTemplate.transform.parent);
        temp.SetActive(true);
        temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -60 + rows.Count * -50, 0);
        temp.transform.GetChild(1).GetComponent<TMP_InputField>().text = kvp.Key;

        AddButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -180 + rows.Count * -50, 0);
        rows.Add(temp);

        if (TableBody.GetComponent<RectTransform>().rect.height < -AddButton.GetComponent<RectTransform>().anchoredPosition.y + 50)
            TableBody.GetComponent<RectTransform>().offsetMin = new Vector2(TableBody.GetComponent<RectTransform>().offsetMin.x,
                TableBody.GetComponent<RectTransform>().rect.height + AddButton.GetComponent<RectTransform>().anchoredPosition.y - 50);
    }
    public void AddAsset()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        FileBrowser.AddQuickLink(AppManager.settings.defaultPath.Split("/")[AppManager.settings.defaultPath.Split("/").Length - 2], AppManager.settings.defaultPath, null);
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Assets", ".jpg", ".png", ".fbx", ".obj"));
        FileBrowser.SetDefaultFilter(".png");
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, AppManager.settings.defaultPath, null, "Select Asset", "Load");

        if (FileBrowser.Success)
            OnFilesSelected(FileBrowser.Result);
    }

    void OnFilesSelected(string[] filePaths)
    {
        for (int i = 0; i < filePaths.Length; i++)
        {
            GameObject temp = Instantiate(rowTemplate, rowTemplate.transform.parent);
            temp.SetActive(true);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -80 + rows.Count * -65, 0);
            temp.transform.GetChild(0).GetComponent<TMP_InputField>().text = FileBrowserHelpers.GetFilename(filePaths[i]);
            temp.transform.GetChild(1).GetComponent<TMP_InputField>().text = filePaths[i];

            if (File.Exists(filePaths[i]))
            {
                byte[] fileData = File.ReadAllBytes(filePaths[i]);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
                temp.transform.GetChild(2).GetComponent<Image>().sprite = sprite;
                temp.transform.GetChild(2).GetComponent<Image>().preserveAspect = true;
            }
            else
            {
                temp.transform.GetChild(2).GetComponent<Image>().sprite = null;
            }

            AddButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -180 + rows.Count * -65, 0);
            rows.Add(temp);

            if (TableBody.GetComponent<RectTransform>().rect.height < -AddButton.GetComponent<RectTransform>().anchoredPosition.y + 50)
                TableBody.GetComponent<RectTransform>().offsetMin = new Vector2(TableBody.GetComponent<RectTransform>().offsetMin.x,
                    TableBody.GetComponent<RectTransform>().rect.height + AddButton.GetComponent<RectTransform>().anchoredPosition.y - 50);
        }
    }
    public void SetPath(GameObject row)
    {
        if (File.Exists(row.transform.GetChild(1).GetComponent<TMP_InputField>().text))
        {
            byte[] fileData = File.ReadAllBytes(row.transform.GetChild(1).GetComponent<TMP_InputField>().text);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
            row.transform.GetChild(2).GetComponent<Image>().sprite = sprite;
            row.transform.GetChild(2).GetComponent<Image>().preserveAspect = true;
        }
        else
        {
            row.transform.GetChild(2).GetComponent<Image>().sprite = null;
        }
    }

    public void RemoveAsset(GameObject row)
    {
        Destroy(row);
        OnEnable();
    }
}
