using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Language;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Rendering;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static TileJSON SaveTile(TileObject tileObject)
    {
        List<SideJSON> sideJSONs = new List<SideJSON>();

        if(tileObject.sides!=null)
            foreach (TileSide side in tileObject.sides)
                sideJSONs.Add(new SideJSON(side.color, side.texture));
        TileJSON tileJSON = new TileJSON(tileObject.tile.posX, tileObject.tile.posY, tileObject.gameObject.transform.position.x, tileObject.gameObject.transform.position.z, tileObject.fake, tileObject.color, tileObject.texture, sideJSONs);

        return tileJSON;
    }
    public static void LoadTile(TileObject tileObject,TileJSON tileJSON)
    {
        object[] list = { int.Parse(tileJSON.positionX), int.Parse(tileJSON.positionY)};
        Tile t = new Tile(list);
        tileObject.tile = t;

        ColorUtility.TryParseHtmlString("#" + tileJSON.color, out Color color);
        tileObject.color = color;

        tileObject.position = new Vector2(int.Parse(tileJSON.realPosX), int.Parse(tileJSON.realPosY));

        tileObject.fake = (tileJSON.fake == "True" ? true : false);

        tileObject.texture = tileJSON.texture;

        if (tileJSON.sides != null)
        {
            for (int i = 0; i < tileJSON.sides.Count; i++)
            {
                ColorUtility.TryParseHtmlString("#" + tileJSON.sides[i].colorS, out Color colorS);
                if(colorS != color)
                    tileObject.sides[i].color =  colorS;
                else
                    tileObject.sides[i].color = Color.clear;
                tileObject.sides[i].texture = tileJSON.sides[i].textureS;
            }
        }
    }

    public static SettingJSON SaveSettings(Settings settings)
    {
        return new SettingJSON(settings.projectName, settings.selectionColor, settings.defaultPath, settings.backgroundColor, settings.xCirc, settings.yCirc);
    }
    public static void LoadSettings(Settings settings, SettingJSON settingJSON)
    {
        settings.projectName = settingJSON.projectName;
        ColorUtility.TryParseHtmlString("#" + settingJSON.selectColor, out Color color);
        settings.selectionColor = color;
        settings.defaultPath = settingJSON.defaultPath;
        settings.xCirc = (settingJSON.xCircular == "True" ? true : false);
        settings.yCirc = (settingJSON.yCircular == "True" ? true : false);
    }

    public static ButtonJSON SaveButton(ButtonObject buttonObject)
    {
        return new ButtonJSON(buttonObject.buttonKey, buttonObject.ClickHandler, buttonObject.buttonvar.active, 
            buttonObject.gameObject.GetComponent<Image>().color,
            buttonObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color, 
            buttonObject.buttonvar.texture,
            buttonObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text, 
            buttonObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().fontSize, 
            buttonObject.gameObject.transform.GetComponent<RectTransform>().anchoredPosition.x,
            buttonObject.gameObject.transform.GetComponent<RectTransform>().anchoredPosition.y,
            buttonObject.gameObject.transform.GetComponent<RectTransform>().sizeDelta.x,
            buttonObject.gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
    }
    public static void LoadButton(ButtonObject buttonObject, ButtonJSON buttonJSON)
    {
        buttonObject.buttonvar = new ButtonVar();
        buttonObject.buttonKey = buttonJSON.ID;
        buttonObject.ClickHandler = buttonJSON.clickHandler;
        buttonObject.buttonvar.active = (buttonJSON.active == "True" ? true : false);
        ColorUtility.TryParseHtmlString("#" + buttonJSON.color, out Color color);
        buttonObject.buttonvar.color = color;
        ColorUtility.TryParseHtmlString("#" + buttonJSON.textColor, out Color textColor);
        buttonObject.buttonvar.textColor = textColor;
        buttonObject.buttonvar.texture = buttonJSON.texture;
        buttonObject.buttonvar.label = buttonJSON.label;
        buttonObject.buttonvar.fontsize = float.Parse(buttonJSON.fontsize);
        buttonObject.position = new Vector2(float.Parse(buttonJSON.positionX), float.Parse(buttonJSON.positionY));
        buttonObject.size = new Vector2(float.Parse(buttonJSON.sizeX), float.Parse(buttonJSON.sizeY));
    }

    public static LabelJSON SaveLabel(LabelObject labelObject)
    {
        return new LabelJSON(labelObject.labelKey, labelObject.labelVar.active, 
            labelObject.gameObject.GetComponent<Image>().color, 
            labelObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color, 
            labelObject.labelVar.texture,
            labelObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text,
            labelObject.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().fontSize,
            labelObject.gameObject.transform.GetComponent<RectTransform>().anchoredPosition.x,
            labelObject.gameObject.transform.GetComponent<RectTransform>().anchoredPosition.y,
            labelObject.gameObject.transform.GetComponent<RectTransform>().sizeDelta.x,
            labelObject.gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
    }
    public static void LoadLabel(LabelObject labelObject, LabelJSON labelJSON)
    {
        labelObject.labelVar = new LabelVar();
        labelObject.labelKey = labelJSON.ID;
        labelObject.labelVar.active = (labelJSON.active == "True" ? true : false);
        ColorUtility.TryParseHtmlString("#" + labelJSON.color, out Color color);
        labelObject.labelVar.color = color;
        ColorUtility.TryParseHtmlString("#" + labelJSON.textColor, out Color textColor);
        labelObject.labelVar.textColor = textColor;
        labelObject.labelVar.texture = labelJSON.texture;
        labelObject.labelVar.text = labelJSON.text;
        labelObject.labelVar.fontsize = float.Parse(labelJSON.fontsize);
        labelObject.position = new Vector2(float.Parse(labelJSON.positionX), float.Parse(labelJSON.positionY));
        labelObject.size = new Vector2(float.Parse(labelJSON.sizeX), float.Parse(labelJSON.sizeY));
    }
    public static ImageJSON SaveImage(ImageObject imageObject)
    {
        return new ImageJSON(imageObject.ID,
            imageObject.texture,
            imageObject.gameObject.transform.position.x,
            imageObject.gameObject.transform.position.z,
            imageObject.gameObject.transform.GetChild(0).localScale.x,
            imageObject.gameObject.transform.GetChild(0).localScale.z,
            imageObject.gameObject.transform.eulerAngles.y);
    }
    public static void LoadImage(ImageObject imageObject, ImageJSON imageJSON)
    {
        imageObject.ID = imageJSON.ID;
        imageObject.texture = imageJSON.texture;
        imageObject.position = new Vector3(float.Parse(imageJSON.positionX), 0, float.Parse(imageJSON.positionY));
        imageObject.size = new Vector3(float.Parse(imageJSON.sizeX), 0, float.Parse(imageJSON.sizeY));
        imageObject.angle = float.Parse(imageJSON.angle);
    }
}
[Serializable]
public class SaveJSON
{
    public List<TileJSON> tiles = new List<TileJSON>();
    public List<ButtonJSON> buttons = new List<ButtonJSON>();
    public List<LabelJSON> labels = new List<LabelJSON>();
    public List<ImageJSON> images = new List<ImageJSON>();
    public List<AssetJSON> assets = new List<AssetJSON>();
    public SettingJSON settings = new SettingJSON();
    public string script;

    public bool valid = false;
    public SaveJSON() { }
    public SaveJSON(List<TileJSON> tiles, List<ButtonJSON> buttons, List<LabelJSON> labels, List<ImageJSON> images, List<AssetJSON> assets, SettingJSON settings, string script)
    {
        this.tiles = tiles;
        this.buttons = buttons;
        this.labels = labels;
        this.images = images;
        this.assets = assets;
        this.settings = settings;
        this.script = script;

        valid = true;
    }
}
[Serializable]
public class TileJSON
{
    public string positionX;
    public string positionY;
    public string realPosX;
    public string realPosY;
    public string fake;
    public string color;
    public string texture;
    public List<SideJSON> sides = new List<SideJSON>();

    public override string ToString()
    {
        return $"positionX={positionX}, positionY={positionY}, realPosX={realPosX}, realPosY={realPosY}, color={color}, texture={texture}";
    }

    public TileJSON() { }

    public TileJSON(int positionX, int positionY, float realPosX, float realPosY, bool fake, Color color, string texture, List<SideJSON> sides)
    {
        this.positionX = positionX.ToString();
        this.positionY = positionY.ToString();
        this.realPosX = realPosX.ToString();
        this.realPosY = realPosY.ToString();
        this.fake = fake.ToString();
        this.color = ColorUtility.ToHtmlStringRGB(color);
        this.texture = texture;
        if (sides != null)
            foreach (var item in sides)
                this.sides.Add(item);
    }
}

[Serializable]
public class SideJSON
{
    public string colorS;
    public string textureS;

    public override string ToString()
    {
        return $"colorS={colorS}, textureS={textureS}";
    }

    public SideJSON() { }
    public SideJSON(Color colorS, string textureS)
    {
        if (colorS.a != 0)
            this.colorS = ColorUtility.ToHtmlStringRGB(colorS);
        else
            this.colorS = "";
        this.textureS = textureS;
    }
}

[Serializable]
public class ButtonJSON
{
    public string ID;
    public string clickHandler;
    public string active;
    public string color;
    public string textColor;
    public string texture;
    public string label;
    public string fontsize;
    public string positionX;
    public string positionY;
    public string sizeX;
    public string sizeY;

    public override string ToString()
    {
        return $"ID={ID}, clickHandler={clickHandler}, active={active}, color={color}, textColor={textColor}, texture={texture}, label={label}, fontsize={fontsize}, positionX={positionX}, positionY={positionY}, sizeX={sizeX}, sizeY={sizeY}";
    }

    public ButtonJSON() { }
    public ButtonJSON(string ID, string clickHandler, bool active, Color color, Color textColor, string texture, string label, float fontsize, float positionX, float positionY, float sizeX, float sizeY)
    {
        this.ID = ID;
        this.clickHandler = clickHandler;
        this.active = active.ToString();
        this.color = ColorUtility.ToHtmlStringRGBA(color);
        this.textColor = ColorUtility.ToHtmlStringRGBA(textColor);
        this.texture = texture;
        this.label = label;
        this.fontsize = fontsize.ToString();
        this.positionX = positionX.ToString();
        this.positionY = positionY.ToString();
        this.sizeX = sizeX.ToString();
        this.sizeY = sizeY.ToString();
    }
}

[Serializable]
public class LabelJSON
{
    public string ID;
    public string active;
    public string color;
    public string textColor;
    public string texture;
    public string text;
    public string fontsize;
    public string positionX;
    public string positionY;
    public string sizeX;
    public string sizeY;

    public override string ToString()
    {
        return $"ID={ID}, active={active}, color={color}, textColor={textColor}, texture={texture}, label={text}, fontsize={fontsize}, positionX={positionX}, positionY={positionY}, sizeX={sizeX}, sizeY={sizeY}";
    }

    public LabelJSON() { }
    public LabelJSON(string ID, bool active, Color color, Color textColor, string texture, string text, float fontsize, float positionX, float positionY, float sizeX, float sizeY)
    {
        this.ID = ID;
        this.active = active.ToString();
        this.color = ColorUtility.ToHtmlStringRGBA(color);
        this.textColor = ColorUtility.ToHtmlStringRGBA(textColor);
        this.texture = texture;
        this.text = text;
        this.fontsize = fontsize.ToString();
        this.positionX = positionX.ToString();
        this.positionY = positionY.ToString();
        this.sizeX = sizeX.ToString();
        this.sizeY = sizeY.ToString();
    }
}

[Serializable]
public class ImageJSON
{
    public string ID;
    public string texture;
    public string positionX;
    public string positionY;
    public string sizeX;
    public string sizeY;
    public string angle;

    public override string ToString()
    {
        return $"ID={ID}, texture={texture}, positionX={positionX}, positionY={positionY}, sizeX={sizeX}, sizeY={sizeY}, angle={angle}";
    }

    public ImageJSON() { }
    public ImageJSON(string ID, string texture, float positionX, float positionY, float sizeX, float sizeY, float angle)
    {
        this.ID = ID;
        this.texture = texture;
        this.positionX = positionX.ToString();
        this.positionY = positionY.ToString();
        this.sizeX = sizeX.ToString();
        this.sizeY = sizeY.ToString();
        this.angle = angle.ToString();
    }
}

[Serializable]
public class AssetJSON
{
    public string ID;
    public string path;
    public string image;

    public override string ToString()
    {
        return $"ID={ID}, path={path}, image={image}";
    }

    public AssetJSON() { }
    public AssetJSON(string ID, string path, string image)
    {
        this.ID = ID;
        this.path = path;
        this.image = image;
    }
}

[Serializable]
public class SettingJSON
{
    public string projectName;
    public string selectColor;
    public string defaultPath;
    public string backgroundColor;
    public string xCircular;
    public string yCircular;

    public override string ToString()
    {
        return $"projectName={projectName}, selectColor={selectColor}, defaultPath={defaultPath}, backgroundColor={backgroundColor}, xCircular={xCircular}, yCircular={yCircular}";
    }

    public SettingJSON() { }
    public SettingJSON(string projectName, Color selectColor, string defaultPath, Color backgroundColor, bool xCircular, bool yCircular)
    {
        this.projectName = projectName;
        this.selectColor = ColorUtility.ToHtmlStringRGB(selectColor);
        this.backgroundColor = ColorUtility.ToHtmlStringRGB(backgroundColor);
        this.defaultPath = defaultPath;
        this.xCircular = xCircular.ToString();
        this.yCircular = yCircular.ToString();
    }
}
