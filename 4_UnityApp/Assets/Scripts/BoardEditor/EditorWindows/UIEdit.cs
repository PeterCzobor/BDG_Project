using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIEdit : MonoBehaviour
{
    public GameObject ColorPicker;

    public Image ColorImage;
    public TMP_Text ColorText;

    public TMP_InputField Name;
    public Toggle Active;

    GameObject activeBody;

    bool imagecolor = true;

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
        if (EditorManager.selectedUI != null)
        {
            switch(EditorManager.selectedUI.GetComponent<UIElement>())
            {
                case ButtonObject:
                    activeBody = transform.GetChild(1).gameObject;
                    activeBody.gameObject.SetActive(true);
                    break;
                case LabelObject:
                    activeBody = transform.GetChild(2).gameObject;
                    activeBody.gameObject.SetActive(true);
                    break;
                /*case ButtonObject:
                    activeBody = transform.GetChild(3).gameObject;
                    break;*/
            }

            ColorImage.color = EditorManager.selectedUI.GetComponent<Image>().color;
            ColorText.color = EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().color;

            if (imagecolor)
                ColorPicker.GetComponent<ColorPicker>().Init(EditorManager.selectedUI.GetComponent<Image>().color, ColorChange);
            else
                ColorPicker.GetComponent<ColorPicker>().Init(EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().color, ColorChange);

            Texture2D texture = EditorManager.selectedUI.gameObject.GetComponent<Image>().mainTexture as Texture2D;
            ColorImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);

            activeBody.transform.GetChild(0).GetComponent<TMP_InputField>().text = EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().text;
            activeBody.transform.GetChild(1).GetComponent<TMP_InputField>().text = EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().fontSize.ToString();

            switch (EditorManager.selectedUI.GetComponent<UIElement>())
            {
                case ButtonObject buttonObject:
                    Name.text = buttonObject.buttonKey;
                    Active.isOn = buttonObject.buttonvar.active;
                    activeBody.transform.GetChild(2).GetComponent<TMP_InputField>().text = buttonObject.ClickHandler;
                    break;
                case LabelObject labelObject:
                    Name.text = labelObject.labelKey;
                    Active.isOn = labelObject.labelVar.active;
                    break;
                    /*case ButtonObject:
                    Name.text = labelObject.labelKey;
                    Active.isOn = labelObject.labelVar.active;
                        break;*/
            }
        }
    }
    private void OnDisable()
    {
        switch (EditorManager.selectedUI.GetComponent<UIElement>())
        {
            case ButtonObject buttonObject:
                buttonObject.buttonKey = Name.text;
                buttonObject.gameObject.name = Name.text;
                buttonObject.buttonvar.active = Active.isOn;
                buttonObject.ClickHandler = activeBody.transform.GetChild(2).GetComponent<TMP_InputField>().text;
                activeBody.gameObject.SetActive(false);
                break;
            case LabelObject labelObject:
                labelObject.labelKey = Name.text;
                labelObject.gameObject.name = Name.text;
                labelObject.labelVar.active = Active.isOn;
                activeBody.gameObject.SetActive(false);
                break;
                /*case ButtonObject:
                Name.text = labelObject.labelKey;
                Active.isOn = labelObject.labelVar.active;
                    break;*/
        }
        activeBody = null;
        EditorManager.selectedUI.GetComponent<UIElement>().enabled = true;
    }

    void ColorChange(Color color)
    {
        if(imagecolor)
        {
            ColorImage.color = color;
            EditorManager.selectedUI.GetComponent<Image>().color = color;
        }
        else
        {
            ColorText.color = color;
            EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().color = color;
        }
    }

    public void TextChange()
    {
       EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().text = activeBody.transform.GetChild(0).GetComponent<TMP_InputField>().text;
    }

    public void FontSizeChange()
    {
       EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().fontSize = int.Parse(activeBody.transform.GetChild(1).GetComponent<TMP_InputField>().text);
    }

    public void ToggleColors(bool image)
    {
        imagecolor = image;
        if(imagecolor)
        {
            Texture2D texture = EditorManager.selectedUI.gameObject.GetComponent<Image>().mainTexture as Texture2D;
            ColorImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
            ColorPicker.GetComponent<ColorPicker>().Init(EditorManager.selectedUI.GetComponent<Image>().color, ColorChange);
        }
        else
        {
            ColorPicker.GetComponent<ColorPicker>().Init(EditorManager.selectedUI.transform.GetChild(0).GetComponent<TMP_Text>().color, ColorChange);
        }
    }
}
