using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TileSide : MonoBehaviour
{
    public Color color;
    public string texture;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CopyTileSide(TileSide other)
    {
        color = other.color;
        texture = other.texture;

        if (color != Color.clear)
        {
            //GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshRenderer>().material.color = color;
        }
        else
            GetComponent<MeshRenderer>().enabled = false;

        if (texture != null && texture != "")
        {
            GetComponent<MeshRenderer>().enabled = true;
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
    }
}
