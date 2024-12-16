using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileInfo : MonoBehaviour
{
    public GameObject ColorTexture;
    //public GameObject ColorWindow;

    public TMP_InputField TileX;
    public TMP_InputField TileY;
    public Toggle IntablToggle;

    GameObject subject;

    public FlexibleColorPicker fcp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool loadingInfo=false;
    private void OnEnable()
    {
        loadingInfo = true;

        if (EditorManager.selected.Count > 0)
        {
            foreach (TileObject to in EditorManager.selected)
            {
                if (to.tile.posX != EditorManager.selected[EditorManager.selected.Count - 1].tile.posX)
                    TileX.text = "?";
                else
                    TileX.text = EditorManager.selected[0].tile.posX.ToString();
                if (to.tile.posY != EditorManager.selected[EditorManager.selected.Count - 1].tile.posY)
                    TileY.text = "?";
                else
                    TileY.text = EditorManager.selected[0].tile.posY.ToString();

                if (to.color != EditorManager.selected[EditorManager.selected.Count - 1].color || to.texture != EditorManager.selected[EditorManager.selected.Count - 1].texture)
                {
                    ColorTexture.transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
                    ColorTexture.GetComponent<Image>().sprite = null;
                    fcp.SetColor(Color.white);
                    ColorTexture.GetComponent<Image>().color = Color.white;
                    break;
                }
                else
                {
                    ColorTexture.transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
                    fcp.SetColor(EditorManager.selected[0].GetComponent<TileObject>().color);
                    ColorTexture.GetComponent<Image>().color = EditorManager.selected[0].GetComponent<TileObject>().color;
                    Texture2D texture = EditorManager.selected[0].gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                    ColorTexture.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
                }
                IntablToggle.isOn = !EditorManager.selected[0].fake;
            }
        }
        else if(EditorManager.selectedTS.Count > 0)
        {
            foreach (TileSide ts in EditorManager.selectedTS)
            {
                if (ts.color != EditorManager.selectedTS[EditorManager.selectedTS.Count - 1].color || ts.texture != EditorManager.selectedTS[EditorManager.selectedTS.Count - 1].texture)
                {
                    ColorTexture.transform.GetChild(0).GetComponent<TMP_Text>().enabled = true;
                    ColorTexture.GetComponent<Image>().sprite = null;
                    fcp.SetColor(Color.white);
                }
                else
                {
                    ColorTexture.transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
                    fcp.SetColor(EditorManager.selectedTS[0].GetComponent<TileSide>().color);
                    Texture2D texture = EditorManager.selectedTS[0].gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                    ColorTexture.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
                }
            }
        }

        loadingInfo = false;
    }

    private void OnDisable()
    {
        if (EditorManager.selected.Count > 0)
        {
            CommandManager.ExecuteCommand(new TileColorCommand(EditorManager.selected, EditorManager.selected[0].GetComponent<MeshRenderer>().material.color));
        }
    }

    public void ColorChange()
    {
        if (!loadingInfo)
        {
            Color color = fcp.color;
            ColorTexture.transform.GetChild(0).GetComponent<TMP_Text>().enabled = false;
            ColorTexture.GetComponent<Image>().color = color;
            if (EditorManager.selected.Count > 0)
            {
                foreach (TileObject to in EditorManager.selected)
                    to.GetComponent<MeshRenderer>().material.color = color;
            }
            else if (EditorManager.selectedTS.Count > 0)
            {
                foreach (TileSide ts in EditorManager.selectedTS)
                    ts.color = color;
            }
        }
    }

    public void TextureChange()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        FileBrowser.AddQuickLink(AppManager.settings.defaultPath.Split("/")[AppManager.settings.defaultPath.Split("/").Length - 2], AppManager.settings.defaultPath, null);
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.SetDefaultFilter(".png");
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, AppManager.settings.defaultPath, null, "Select Asset", "Load");

        if (FileBrowser.Success)
        {
            byte[] fileData = File.ReadAllBytes(FileBrowser.Result[0]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100);
            ColorTexture.GetComponent<Image>().sprite = sprite;

            if (EditorManager.selected.Count > 0)
            {
                CommandManager.ExecuteCommand(new TileTextureCommand(EditorManager.selected, Convert.ToBase64String(fileData)));
            }
            else if (EditorManager.selectedTS.Count > 0)
            {
                foreach (TileSide ts in EditorManager.selectedTS)
                {
                    ts.gameObject.GetComponent<MeshRenderer>().material.mainTexture = texture;
                    ts.GetComponent<TileSide>().texture = Convert.ToBase64String(fileData);
                }
            }
        }
    }

    public void NameChange()
    {
        foreach (TileObject to in EditorManager.selected)
        {
            if(TileX.text != "?")
                to.tile.posX = int.Parse(TileX.text);
            if (TileY.text != "?")
                to.tile.posY = int.Parse(TileY.text);
        }
    }

    public void ToggleIntabl()
    {
        if (EditorManager.selected.Count > 0 && !loadingInfo)
        {
            foreach (TileObject to in EditorManager.selected)
                to.fake = !to.fake;
        }
    }

    public void Advanced()
    {
        if (EditorManager.selected.Count > 0)
        {
            foreach (TileObject to in EditorManager.selected)
            {
                to.color = ColorTexture.GetComponent<Image>().color;
                to.GetComponent<MeshRenderer>().material.color = to.color;
                for (int i = 0; i < to.gameObject.transform.childCount-1; i++)
                {
                    if (to.gameObject.transform.GetChild(i).gameObject.activeSelf)
                        to.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = to.gameObject.transform.GetChild(i).GetComponent<TileSide>().color;
                }
            }
        }

        if (EditorManager.selected.Count > 0)
        {
            foreach (TileObject item in EditorManager.tileObjects)
            {
                if (!EditorManager.selected.Contains(item))
                    item.gameObject.SetActive(false);
                else
                {
                    for (int i = 0; i < item.gameObject.transform.childCount - 1; i++)
                    {
                        item.gameObject.transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
                        item.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
                        item.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.white;
                        if (item.gameObject.transform.GetChild(i).GetComponent<TileSide>().color == Color.clear && item.gameObject.transform.GetChild(i).GetComponent<TileSide>().texture == "")
                        {
                            item.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = item.GetComponent<TileObject>().color;
                            item.gameObject.transform.GetChild(i).GetComponent<TileSide>().color = item.GetComponent<TileObject>().color;
                            item.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.mainTexture = item.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
                            item.gameObject.transform.GetChild(i).GetComponent<TileSide>().texture = item.GetComponent<TileObject>().texture;
                        }
                        item.gameObject.transform.GetChild(i).GetComponent<TileSide>().DeSelect();
                    }
                }
            }
            GameObject.Find("Manager").GetComponent<EditorManager>().ToggleSideEdit(true);
            EditorManager.selected.Clear();
        }
    }
}
