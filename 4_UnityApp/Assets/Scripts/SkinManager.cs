using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public List<Color> Dark_Button1Colors = new List<Color>();
    public List<Color> Dark_Button2Colors = new List<Color>();
    public List<Color> Dark_CloseButtonColors = new List<Color>();
    public Color Dark_InputFieldColors = new Color();
    public Color Dark_Image1Colors = new Color();
    public Color Dark_Image2Colors = new Color();
    public Color Dark_Image3Colors = new Color();
    public Color Dark_SelectionImageColors = new Color();
    public Color Dark_Text1Colors = new Color();
    public Color Dark_Text2Colors = new Color();
    public Color Dark_BackgroundColor = new Color();
    public UISkin FileBrowserDark;
    public DialogSkin DialogBoxDark;


    public List<Color> Light_Button1Colors = new List<Color>();
    public List<Color> Light_Button2Colors = new List<Color>();
    public List<Color> Light_CloseButtonColors = new List<Color>();
    public Color Light_InputFieldColors = new Color();
    public Color Light_Image1Colors = new Color();
    public Color Light_Image2Colors = new Color();
    public Color Light_Image3Colors = new Color();
    public Color Light_SelectionImageColors = new Color();
    public Color Light_Text1Colors = new Color();
    public Color Light_Text2Colors = new Color();
    public Color Light_BackgroundColor = new Color();
    public UISkin FileBrowserLight;
    public DialogSkin DialogBoxLight;


    List<Color> Button1Colors = new List<Color>();
    List<Color> Button2Colors = new List<Color>();
    List<Color> CloseButtonColors = new List<Color>();
    Color InputFieldColors = new Color();
    Color Image1Colors = new Color();
    Color Image2Colors = new Color();
    Color Image3Colors = new Color();
    Color SelectionImageColors = new Color();
    Color Text1Colors = new Color();
    Color Text2Colors = new Color();
    Color BackgroundColor = new Color();


    public void ReSkin()
    {
        Screen.fullScreen = true && AppManager.generalSettings.fullScreen == 1;
        if (AppManager.generalSettings.theme == 0)
        {
            Button1Colors = Dark_Button1Colors;
            Button2Colors = Dark_Button2Colors;
            CloseButtonColors = Dark_CloseButtonColors;
            InputFieldColors = Dark_InputFieldColors;
            Image1Colors = Dark_Image1Colors;
            Image2Colors = Dark_Image2Colors;
            Image3Colors = Dark_Image3Colors;
            SelectionImageColors = Dark_SelectionImageColors;
            Text1Colors = Dark_Text1Colors;
            Text2Colors = Dark_Text2Colors;
            BackgroundColor = Dark_BackgroundColor;
            FileBrowser.Skin = FileBrowserDark;
            DialogBox.Skin = DialogBoxDark;
        }
        else
        {
            Button1Colors = Light_Button1Colors;
            Button2Colors = Light_Button2Colors;
            CloseButtonColors = Light_CloseButtonColors;
            InputFieldColors = Light_InputFieldColors;
            Image1Colors = Light_Image1Colors;
            Image2Colors = Light_Image2Colors;
            Image3Colors = Light_Image3Colors;
            SelectionImageColors = Light_SelectionImageColors;
            Text1Colors = Light_Text1Colors;
            Text2Colors = Light_Text2Colors;
            BackgroundColor = Light_BackgroundColor;
            FileBrowser.Skin = FileBrowserLight;
            DialogBox.Skin = DialogBoxLight;
        }
        ButtonReSkin();
        ImageReSkin();
        TextReSkin();
        BackgroundReSkin();
    }

    void ButtonReSkin()
    {
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button button in buttons)
        {
            if (button.CompareTag("mainButton"))
            {
                var colors = button.colors;
                colors.normalColor = Button1Colors[0];
                colors.highlightedColor = Button1Colors[1];
                colors.pressedColor = Button1Colors[2];
                colors.selectedColor = Button1Colors[0];
                button.colors = colors;
            }
        }
        foreach (Button button in buttons)
        {
            if (button.CompareTag("startButton"))
            {
                var colors = button.colors;
                colors.normalColor = Button2Colors[0];
                colors.highlightedColor = Button2Colors[1];
                colors.pressedColor = Button2Colors[2];
                colors.selectedColor = Button1Colors[0];
                button.colors = colors;
            }
        }
        foreach (Button button in buttons)
        {
            if (button.CompareTag("closeButton"))
            {
                var colors = button.colors;
                colors.normalColor = CloseButtonColors[0];
                colors.highlightedColor = CloseButtonColors[1];
                colors.pressedColor = CloseButtonColors[2];
                colors.selectedColor = CloseButtonColors[0];
                button.colors = colors;
            }
        }
    }
    void ImageReSkin()
    {
        Image[] images = Resources.FindObjectsOfTypeAll<Image>();
        Image[] inputFields = Resources.FindObjectsOfTypeAll<Image>();

        foreach (Image image in images)
        {
            if (image.CompareTag("mainImage"))
            {
                image.color = Image1Colors;
            }
            if (image.CompareTag("menuImage"))
            {
                image.color = Image2Colors;
            }
            if (image.CompareTag("inverseImage"))
            {
                image.color = Image3Colors;
            }
            if (image.CompareTag("selectionImage"))
            {
                image.color = SelectionImageColors;
            }
        }
        foreach (Image inputField in inputFields)
        {
            if (inputField.CompareTag("inputField"))
            {
                inputField.color = InputFieldColors;
            }
        }
    }
    void TextReSkin()
    {
        TMP_Text[] texts = Resources.FindObjectsOfTypeAll<TMP_Text>();

        foreach (TMP_Text text in texts)
        {
            if (text.CompareTag("mainText"))
            {
                text.color = Text1Colors;
            }
        }
        foreach (TMP_Text text in texts)
        {
            if (text.CompareTag("inverseText"))
            {
                text.color = Text2Colors;
            }
        }
    }
    void BackgroundReSkin()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Camera.main.backgroundColor = BackgroundColor;
        }
    }
}
