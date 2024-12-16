using Language;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System;

public class AssetsManager : MonoBehaviour
{
    public GameObject rowTemplate;
    public GameObject AddButton;
    public GameObject TableHeader;
    public GameObject TableBody;
    public List<GameObject> rows = new List<GameObject>();
    public Dictionary<object, AssetJSON> assets = new Dictionary<object, AssetJSON>();

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

        AddButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -180, 0);
        foreach (var asset in EditorManager.assets)
        {
            AddAsset(asset);
        }
    }
    private void OnDisable()
    {
        EditorManager.assets.Clear();

        foreach (var kvp in assets)
        {
            EditorManager.assets.Add(kvp.Value);
        }

        CameraManager.SetCamera(true);
    }

    void AddAsset(AssetJSON asset)
    {
        TableHeader.SetActive(true);
        GameObject temp = Instantiate(rowTemplate, rowTemplate.transform.parent);
        temp.SetActive(true);
        temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -80 + rows.Count * -65, 0);
        temp.transform.GetChild(0).GetComponent<TMP_InputField>().text = asset.ID;
        temp.transform.GetChild(1).GetComponent<TMP_InputField>().text = asset.path;

            byte[] fileData = Convert.FromBase64String(asset.image);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
            temp.transform.GetChild(2).GetComponent<Image>().sprite = sprite;
            temp.transform.GetChild(2).GetComponent<Image>().preserveAspect = true;

        assets[temp] = new AssetJSON(asset.ID, asset.path, asset.image);

        AddButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -180 + rows.Count * -65, 0);
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
        FileBrowser.AddQuickLink(AppManager.settings.defaultPath.Split("/")[AppManager.settings.defaultPath.Split("/").Length-2], AppManager.settings.defaultPath, null);
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Assets", ".jpg", ".png", ".fbx", ".obj"));
        FileBrowser.SetDefaultFilter(".png");
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, AppManager.settings.defaultPath, null, "Select Asset", "Load");

        if (FileBrowser.Success)
            OnFilesSelected(FileBrowser.Result);
    }

    void OnFilesSelected(string[] filePaths)
    {
        TableHeader.SetActive(true);
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

                assets[temp] = new AssetJSON(FileBrowserHelpers.GetFilename(filePaths[i]), filePaths[i], Convert.ToBase64String(fileData));
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
        assets.Remove(row);
        Destroy(row);
        OnEnable();
    }
}
