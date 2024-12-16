using Language;
using Newtonsoft.Json;
using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class EditorManager : MonoBehaviour
{
    public GameObject TileInfo;
    public GameObject Button2D;
    public GameObject Button3D;
    public GameObject DoneButton;
    public GameObject DoneTSButton;
    public GameObject FileButton;
    public GameObject ScriptButton;
    public GameObject BoardButton;
    public GameObject UIButton;
    public GameObject SettingsButton;
    public GameObject AdvancedButton;
    public GameObject CloseButton;
    public TMP_InputField Name;
    public static TMP_InputField Namee;

    public static List<TileObject> selected = new List<TileObject>();
    public static List<TileSide> selectedTS = new List<TileSide>();

    public static GameObject selectedUI;

    public static List<TileObject> tileObjects = new List<TileObject>();
    public static List<UIElement> uiObjects = new List<UIElement>();
    public static List<ImageObject> imageObjects = new List<ImageObject>();
    public static List<GameObject> imageButtons = new List<GameObject>();
    public static List<AssetJSON> assets = new List<AssetJSON>();

    public static int BoardX = 0;
    public static int BoardY = 0;
    public static string Script = "";

    // Start is called before the first frame update
    void Start()
    {
        AppManager.settings.projectName = "MyProject";
        Name.text = AppManager.settings.projectName;
        GameObject.Find("CreatedContent").GetComponent<SkinManager>().ReSkin();

        if(AppManager.saved.valid)
        {
            LoadProject.LoadGame("");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            if (selected.Count > 0)
            {
                CommandManager.ExecuteCommand(new TileDeleteCommand(selected));
                TileInfo.SetActive(false);
            }
            if (selectedUI != null)
            {
                uiObjects.Remove(selectedUI.GetComponent<UIElement>());
                Destroy(selectedUI.gameObject);
                selected.Clear();
            }

        }
    }
    public static void DeleteTile(List<TileObject> Tos)
    {
        foreach (TileObject t in Tos)
        {
            tileObjects.Remove(t);
            Destroy(t.gameObject);
        }
        selected.Clear();
    }
    public static TileObject redoDeleteTile()
    {
        GameObject temp = Instantiate(GameObject.Find("Tile"));
        tileObjects.Add(temp.GetComponent<TileObject>());
        return temp.GetComponent<TileObject>();
    }

    public void StateMachine(Object caller)
    {
        if (caller is TileObject T)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                TileInfo.SetActive(false);
                if (selected.Contains(T))
                {
                    selected.Remove(T);
                    T.DeSelect();
                }
                else
                {
                    selected.Add(T);
                    T.Select();
                }
                TileInfo.SetActive(true);
            }
            else
            {
                TileInfo.SetActive(false);

                foreach(TileObject item in selected)
                {
                    item.DeSelect();
                }
                if (selected.Count == 1 && selected[0] == T)
                {
                    selected.Clear();
                }
                else
                {
                    selected.Clear();
                    selected.Add(T);
                    T.Select();

                    TileInfo.SetActive(true);
                }
            }
            
        }
        else if (caller is TileSide Ts)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                TileInfo.SetActive(false);
                if (selectedTS.Contains(Ts))
                {
                    selectedTS.Remove(Ts);
                    Ts.DeSelect();
                }
                else
                {
                    selectedTS.Add(Ts);
                    Ts.Select();
                }
                TileInfo.SetActive(true);
            }
            else
            {
                TileInfo.SetActive(false);

                foreach (TileSide item in selectedTS)
                {
                    item.DeSelect();
                }
                if (selectedTS.Count == 1 && selectedTS[0] == Ts)
                {
                    selectedTS.Clear();
                }
                else
                {
                    selectedTS.Clear();
                    selectedTS.Add(Ts);
                    Ts.Select();

                    TileInfo.SetActive(true);
                }
            }
        }
    }

    public void EnableButtons(bool enable)
    {
        Button2D.SetActive(enable);
        Button3D.SetActive(enable);
        DoneButton.SetActive(enable);
    }

    public void ClearBoard()
    {
        foreach (TileObject t in tileObjects)
        {
            Destroy(t.gameObject);
        }
        tileObjects.Clear();
        foreach (UIElement u in uiObjects)
        {
            Destroy(u.gameObject);
        }
        uiObjects.Clear();
        foreach (ImageObject i in imageObjects)
        {
            Destroy(i.gameObject);
        }
        imageObjects.Clear();
        foreach (GameObject i in imageButtons)
        {
            Destroy(i);
        }
        imageObjects.Clear();
        assets.Clear();
        TileInfo.SetActive(false);
    }

    public void BoardFinalized()
    {
        List<TileJSON> tileJSONs = new List<TileJSON>();
        foreach (TileObject item in tileObjects)
        {
            tileJSONs.Add(SaveLoad.SaveTile(item));
        }
        List<ButtonJSON> buttonJSONs = new List<ButtonJSON>();
        List<LabelJSON> labelJSONs = new List<LabelJSON>();
        foreach (UIElement item in uiObjects)
        {
            if(item is ButtonObject b)
                buttonJSONs.Add(SaveLoad.SaveButton(b));
            if(item is LabelObject l)
                labelJSONs.Add(SaveLoad.SaveLabel(l));
        }
        List<ImageJSON> imageJSONs = new List<ImageJSON>();
        foreach (ImageObject item in imageObjects)
        {
            imageJSONs.Add(SaveLoad.SaveImage(item));
        }
        List<AssetJSON> assetJSONs = new List<AssetJSON>();
        foreach (var item in assets)
        {
            assetJSONs.Add(new AssetJSON(item.ID,item.path,item.image));
        }
        SettingJSON settingJSON = SaveLoad.SaveSettings(AppManager.settings);

        if (File.Exists(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg")))
        {
            StreamReader reader = new StreamReader(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg"));
            Script = reader.ReadToEnd();
            reader.Close();
        }

        Dictionary<string, object> assetD = new Dictionary<string, object>();
        foreach (var asset in assets)
        {
            assetD[asset.ID] = asset.path;
        }

        Dictionary<string, object> objectVariables = new Dictionary<string, object>();
        foreach (UIElement item in uiObjects)
        {
            if (item is ButtonObject b)
                objectVariables[b.buttonKey] = "Button";
            if (item is LabelObject l)
                objectVariables[l.labelKey] = "Label";
        }
        objectVariables = objectVariables.Union(assetD).ToDictionary(pair => pair.Key, pair => pair.Value);
        string objectVariablesJSON = JsonConvert.SerializeObject(objectVariables, new JsonSerializerSettings()
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        using (StreamWriter writer = new StreamWriter(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".json")))
        {
            writer.Write(objectVariablesJSON);
            writer.Close();
        }

        AppManager.saved = new SaveJSON(tileJSONs, buttonJSONs, labelJSONs, imageJSONs, assetJSONs, settingJSON, Script);
    }

    public void StartGameButton()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        BoardFinalized();

        PipeClient.SendMessageToServer(Path.Combine(AppManager.globalPath + "/Scripts", AppManager.settings.projectName + ".bdg"));
        yield return new WaitUntil(() => PipeClient.messageGot == true);
        List<string> erros = PipeClient.GetMessageFromServer();
        foreach (string erro in erros)
            Debug.Log(erro);
        if (erros.Count > 0)
        {
            yield return DialogBox.ShowDialog("Fix all the compile errors before running the game", "OK");
            yield break;
        }

        string savedJSON = JsonUtility.ToJson(AppManager.saved);

        string path = "";
#if UNITY_EDITOR
        path = @"C:\Users\czobo\Desktop\boardgame\";
#else
        path = AppDomain.CurrentDomain.BaseDirectory;
#endif
        using (StreamWriter writer = new StreamWriter(path + "temp.board"))
        {
            writer.Write(savedJSON);
            writer.Close();
        }
        ClearBoard();
        //AppManager.debugMode = true;
        AppManager.ChangeScene("GameScene");
    }

    public void TSDone()
    {
        if(selectedTS!=null)
            foreach (TileSide ts in EditorManager.selectedTS)
                ts.GetComponent<MeshRenderer>().material.color = ts.color;

        foreach (TileObject item in tileObjects)
        {
            if (item.gameObject.activeSelf)
            {
                for (int i = 0; i < item.gameObject.transform.childCount-1; i++)
                {
                    if (item.gameObject.transform.GetChild(i).GetComponent<TileSide>().color == item.gameObject.GetComponent<TileObject>().color &&
                        item.gameObject.transform.GetChild(i).GetComponent<TileSide>().texture == item.gameObject.GetComponent<TileObject>().texture)
                    {
                        item.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                        item.gameObject.transform.GetChild(i).GetComponent<TileSide>().color = Color.clear;
                        item.gameObject.transform.GetChild(i).GetComponent<TileSide>().texture = "";

                    }
                    item.gameObject.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
                    item.gameObject.transform.GetChild(i).GetComponent<TileSide>().Select();
                }
                item.DeSelect();
            }
            else
            {
                item.gameObject.SetActive(true);
            }
        }
        ToggleSideEdit(false);
        selectedTS.Clear();
    }

    public void NameChange()
    {
        AppManager.settings.projectName = Name.text;
    }

    public void Exit()
    {
        ClearBoard();
        AppManager.ChangeScene("StartScene");
    }

    public void ToggleSideEdit(bool side)
    {
        if(side)
        {
            Button2D.SetActive(false);
            Button3D.SetActive(false);
            DoneButton.SetActive(false);
            DoneTSButton.SetActive(true);
            FileButton.SetActive(false);
            ScriptButton.SetActive(false);
            BoardButton.SetActive(false);
            UIButton.SetActive(false);
            SettingsButton.SetActive(false);
            AdvancedButton.SetActive(false);
        }
        else
        {
            AdvancedButton.SetActive(true);
            Button2D.SetActive(true);
            Button3D.SetActive(true);
            DoneButton.SetActive(true);
            DoneTSButton.SetActive(false);
            FileButton.SetActive(true);
            ScriptButton.SetActive(true);
            BoardButton.SetActive(true);
            UIButton.SetActive(true);
            SettingsButton.SetActive(true);
        }
    }

    public static void CreateImageButtons()
    {
        imageButtons.Clear();
        foreach (ImageObject item in imageObjects)
        {
            GameObject button = Instantiate(GameObject.Find("ImageSelect"), GameObject.Find("Canvas").transform);
            button.transform.SetAsFirstSibling();
            button.SetActive(true);
            button.GetComponent<RectTransform>().anchoredPosition = new Vector3(-120, -200 + (imageButtons.Count) * -40, 0);
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = item.ID;
            imageButtons.Add(button);
        }
    }

    GameObject SelectedImage;
    public void ImageSelection(GameObject image)
    {
        if (image != SelectedImage)
        {
            if (SelectedImage != null)
                DeselectImage(SelectedImage);
            SelectedImage = image;
            SelectImage(image);
        }
        else
        {
            DeselectImage(SelectedImage);
            SelectedImage = null;
        }
    }
    void SelectImage(GameObject image)
    {
        image.GetComponent<Image>().color = Color.white;
        image.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
        GameObject activeImage = GameObject.Find(image.transform.GetChild(0).GetComponent<TMP_Text>().text);
        activeImage.GetComponent<ImageElement>().enabled = true;
        activeImage.GetComponent<BoxCollider>().enabled = true;
        for (int i = 1; i < activeImage.transform.childCount; i++)
        {
            activeImage.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    void DeselectImage(GameObject image)
    {
        image.GetComponent<Image>().color = Color.black;
        image.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        GameObject activeImage = GameObject.Find(image.transform.GetChild(0).GetComponent<TMP_Text>().text);
        activeImage.GetComponent<ImageElement>().enabled = false;
        activeImage.GetComponent<BoxCollider>().enabled = false;
        for (int i = 1; i < activeImage.transform.childCount; i++)
        {
            activeImage.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    GameObject ActiveWindow;
    public void WindowHandler(GameObject window)
    {
        if(window != CloseButton && window != ActiveWindow)
        {
            if(ActiveWindow != null)
                ActiveWindow.SetActive(false);
            ActiveWindow = window;
            window.SetActive(true);
            CloseButton.SetActive(true);
        }
        else
        {
            if (ActiveWindow != null)
                ActiveWindow.SetActive(false);
            CloseButton.SetActive(false);
            ActiveWindow = null;
        }
    }
}
