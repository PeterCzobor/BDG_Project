using Language;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LabelObject : UIElement
{
    public Vector2 position;
    public Vector2 size;

    public LabelVar labelVar;
    public string labelKey;

    public override string VariableKey { get => labelKey; set => labelKey = value; }
    public override object VariableObject { get => labelVar; set => labelVar = (LabelVar)value; }

    public override void CreateElement(object[] args)
    {
        if (args[0] is Vector2 position_)
            position = position_;
        if (args[1] is Vector2 size_)
            size = size_;
        if (args[2] is LabelVar labelVar_)
            labelVar = labelVar_;
        if (args[3] is string labelKey_)
            labelKey = labelKey_;

        if (labelVar.active == false && SceneManager.GetActiveScene().name != "BoardEditor")
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }

        GetComponent<Image>().color = labelVar.color;
        transform.GetChild(0).GetComponent<TMP_Text>().color = labelVar.textColor;
        transform.GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetComponent<RectTransform>().sizeDelta = size;

        transform.GetChild(0).GetComponent<TMP_Text>().text = labelVar.text;
        transform.GetChild(0).GetComponent<TMP_Text>().fontSize = labelVar.fontsize;

        if (labelVar.texture != null && labelVar.texture != "")
        {
            byte[] fileData = File.ReadAllBytes(AppManager.settings.defaultPath + labelVar.texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100);
        }
    }

    public override void CopyElement(object other)
    {
        if (other is LabelObject labelObject)
        {
            position = labelObject.position;
            size = labelObject.size;
            labelVar = labelObject.labelVar;
            labelKey = labelObject.labelKey;
        }

        if (labelVar.active == false && SceneManager.GetActiveScene().name != "BoardEditor")
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }

        GetComponent<Image>().color = labelVar.color;
        transform.GetChild(0).GetComponent<TMP_Text>().color = labelVar.textColor;
        transform.GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetComponent<RectTransform>().sizeDelta = size;

        transform.GetChild(0).GetComponent<TMP_Text>().text = labelVar.text;
        transform.GetChild(0).GetComponent<TMP_Text>().fontSize = labelVar.fontsize;

        if (labelVar.texture != null && labelVar.texture != "")
        {
            byte[] fileData = File.ReadAllBytes(AppManager.settings.defaultPath + labelVar.texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100);
        }
    }

    public override void UpdateElement()
    {
        if (labelVar.active == false)
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }
        transform.GetChild(0).GetComponent<TMP_Text>().text = labelVar.text;
    }
}
