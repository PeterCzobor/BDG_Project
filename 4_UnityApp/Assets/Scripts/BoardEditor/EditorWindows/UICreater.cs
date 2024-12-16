using Language;
using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UICreater : MonoBehaviour
{
    public GameObject HighLight;

    public GameObject ButtonTemplate;
    public GameObject LabelTemplate;
    public GameObject InputFieldTemplate;
    public GameObject ImageTemplate;

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

    public void AddButton()
    {
        GameObject temp = Instantiate(ButtonTemplate, GameObject.Find("Canvas").transform);
        temp.transform.SetAsFirstSibling();
        ButtonVar buttonVar = new ButtonVar(true, Color.white, Color.black, "", "Button", 24);

        int i = 0;
        while(true)
        {
            if (GameObject.Find("Button" + i) == null)
            {
                temp.name = "Button"+i;
                break;
            }
            i++;
        }
        temp.GetComponent<ButtonObject>().CreateElement(new object[] { "", Vector2.zero, new Vector2(150, 100), buttonVar, temp.name });

        temp.transform.SetAsFirstSibling();
        temp.transform.localPosition = Vector3.zero;
        EditorManager.uiObjects.Add(temp.GetComponent<ButtonObject>());
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
    public void AddLabel()
    {
        GameObject temp = Instantiate(LabelTemplate, GameObject.Find("Canvas").transform);
        temp.transform.SetAsFirstSibling();
        LabelVar labelVar = new LabelVar(true, Color.white, Color.black, "", "Label", 24);

        int i = 0;
        while (true)
        {
            if (GameObject.Find("Label" + i) == null)
            {
                temp.name = "Label" + i;
                break;
            }
            i++;
        }
        temp.GetComponent<LabelObject>().CreateElement(new object[] { Vector2.zero, new Vector2(150, 100), labelVar, temp.name });

        temp.transform.SetAsFirstSibling();
        temp.transform.localPosition = Vector3.zero;
        EditorManager.uiObjects.Add(temp.GetComponent<LabelObject>());
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
    public void AddInputField()
    {
        GameObject temp = Instantiate(InputFieldTemplate, GameObject.Find("Canvas").transform);
        temp.transform.SetAsFirstSibling();
        temp.transform.localPosition = Vector3.zero;
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }
    public void AddImage()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
        GameObject.Find("Manager").GetComponent<EditorManager>().WindowHandler(gameObject);
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        FileBrowser.AddQuickLink(AppManager.settings.defaultPath.Split("/")[AppManager.settings.defaultPath.Split("/").Length - 2], AppManager.settings.defaultPath, null);
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.SetDefaultFilter(".png");
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, AppManager.settings.defaultPath, null, "Select Asset", "Load");

        if (FileBrowser.Success)
        {
            GameObject temp = Instantiate(ImageTemplate);
            int i = 0;
            while (true)
            {
                if (GameObject.Find("Image" + i) == null)
                {
                    temp.name = "Image" + i;
                    break;
                }
                i++;
            }
            temp.GetComponent<ImageObject>().CreateElement(new object[] { Vector3.zero, Vector3.zero, 0.0f, temp.name, FileBrowser.Result[0] });
            EditorManager.imageObjects.Add(temp.GetComponent<ImageObject>());

            EditorManager.CreateImageButtons();
        }
    }

}
