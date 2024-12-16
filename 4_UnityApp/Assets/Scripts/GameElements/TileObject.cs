using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Language;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using System;

public class TileObject : GameElement
{
    public string tileKey;
    public Tile tile;
    public Color color;
    public Vector2 position;
    public bool fake = false;
    public string texture;

    public List<TileSide> sides;

    public override string VariableKey { get => tileKey; set => tileKey = value; }
    public override object VariableObject { get => tile; set => tile = (Tile)value; }

    public override void CreateElement(object[] args)
    {
        if (args[0] is Tile tile_)
            tile = tile_;
        if (args[1] is Color color_)
            color = color_;
        if (args[2] is Vector2 position_)
            position = position_;
        if (args[3] is bool fake_)
            fake = fake_;
        if (args[4] is string texture_)
            texture = texture_;
        if (args[5] is List<TileSide> sides_)
            sides = sides_;

        if (texture != null && texture != "")
        {
            byte[] fileData = Convert.FromBase64String(texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            Material material = new Material(Shader.Find("Standard"));
            material.mainTexture = tex;
            GetComponent<MeshRenderer>().material = material;
            GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 1);
            GetComponent<MeshRenderer>().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
            GetComponent<MeshRenderer>().material.SetFloat("_SpecularHighlights", 0f);
        }

        GetComponent<MeshRenderer>().material.color = color;
        transform.position = new Vector3(position.x, 0, position.y);

        if (sides != null)
        {
            for (int i = 0; i < sides.Count; i++)
            {
                transform.GetChild(i).GetComponent<TileSide>().CopyTileSide(sides[i]);
            }
        }
    }

    public override void CopyElement(object other)
    {
        if(other is TileObject tileObject)
        {
            tile = tileObject.tile;
            color = tileObject.color;
            position = tileObject.position;
            fake = tileObject.fake;
            texture = tileObject.texture;
            sides = tileObject.sides;
        }

        if(texture != null && texture != "")
        {
            //byte[] fileData = File.ReadAllBytes(AppManager.settings.defaultPath + texture);
            byte[] fileData = Convert.FromBase64String(texture);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            Material material = new Material(Shader.Find("Standard"));
            material.mainTexture = tex;
            GetComponent<MeshRenderer>().material = material;
            GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 1);
            GetComponent<MeshRenderer>().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
            GetComponent<MeshRenderer>().material.SetFloat("_SpecularHighlights", 0f);
        }

        GetComponent<MeshRenderer>().material.color = color;
        transform.position = new Vector3(position.x, 0, position.y);

        if (sides != null)
        {
            for (int i = 0; i < sides.Count; i++)
            {
                transform.GetChild(i).GetComponent<TileSide>().CopyTileSide(sides[i]);
            }
        }
    }

    public override void UpdateElement()
    {

    }

    public GameObject selection;
    public void Select()
    {
        selection.SetActive(true);
    }
    public void DeSelect()
    {
        selection.SetActive(false);
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (SceneManager.GetActiveScene().name == "BoardEditor")
        {
            GameObject.Find("Manager").GetComponent<EditorManager>().StateMachine(this);
        }
        else if(!fake)
        {
            StartCoroutine(GameObject.Find("Manager").GetComponent<GameManager>().StateMachine(this));
        }
    }
}
