using Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonObject : UIElement
{
    public string ClickHandler;
    public Vector2 position;
    public Vector2 size;

    public ButtonVar buttonvar;
    public string buttonKey;

    public override string VariableKey { get => buttonKey; set => buttonKey = value; }
    public override object VariableObject { get => buttonvar; set => buttonvar = (ButtonVar)value; }

    public override void CreateElement(object[] args)
    {
        if (args[0] is string ClickHandler_)
            ClickHandler = ClickHandler_;
        if (args[1] is Vector2 position_)
            position = position_;
        if (args[2] is Vector2 size_)
            size = size_;
        if (args[3] is ButtonVar buttonvar_)
            buttonvar = buttonvar_;
        if (args[4] is string buttonKey_)
            buttonKey = buttonKey_;

        if (buttonvar.active == false && SceneManager.GetActiveScene().name != "BoardEditor")
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }

        GetComponent<Image>().color = buttonvar.color;
        transform.GetChild(0).GetComponent<TMP_Text>().color = buttonvar.textColor;
        transform.GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetComponent<RectTransform>().sizeDelta = size;

        transform.GetChild(0).GetComponent<TMP_Text>().text = buttonvar.label;
        transform.GetChild(0).GetComponent<TMP_Text>().fontSize = buttonvar.fontsize;

        if (buttonvar.texture != null && buttonvar.texture != "")
        {
            byte[] fileData = Convert.FromBase64String(buttonvar.texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100);
        }
    }

    public override void CopyElement(object other)
    {
        if(other is ButtonObject buttonObject)
        {
            ClickHandler = buttonObject.ClickHandler;
            position = buttonObject.position;
            size = buttonObject.size;
            buttonvar = buttonObject.buttonvar;
            buttonKey = buttonObject.buttonKey;
        }

        if (buttonvar.active == false && SceneManager.GetActiveScene().name != "BoardEditor")
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }

        GetComponent<Image>().color = buttonvar.color;
        transform.GetChild(0).GetComponent<TMP_Text>().color = buttonvar.textColor;
        transform.GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetComponent<RectTransform>().sizeDelta = size;

        transform.GetChild(0).GetComponent<TMP_Text>().text = buttonvar.label;
        transform.GetChild(0).GetComponent<TMP_Text>().fontSize = buttonvar.fontsize;

        if (buttonvar.texture != null && buttonvar.texture != "")
        {
            byte[] fileData = Convert.FromBase64String(buttonvar.texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), 100);
        }
    }

    public override void UpdateElement()
    {
        if (buttonvar.active == false)
        {
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
        }
        else
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
        }
    }
}
