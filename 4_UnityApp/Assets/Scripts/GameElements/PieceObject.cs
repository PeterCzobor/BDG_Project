using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Language;
using System;

public class PieceObject : GameElement
{
    public string pieceKey;
    public Piece piece;

    public override string VariableKey { get => pieceKey; set => pieceKey = value; }
    public override object VariableObject { get => piece; set => piece = (Piece)value; }


    public override void CreateElement(object[] args)
    {
        if (args[0] is Piece piece_)
            piece = piece_;
        if (args[1] is string pieceKey_)
            pieceKey = pieceKey_;

        if (!piece.real)
            return;

        transform.SetParent(GameObject.Find("Tile" + piece.posX.ToString() + "_" + piece.posY.ToString()).transform);
        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);

        if (piece.color != null)
        {
            Color temp;
            ColorUtility.TryParseHtmlString(piece.color, out temp);
            transform.GetComponent<Renderer>().material.color = temp;
            if(piece.texture == null)
            {
                transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            }
        }

        if (piece.texture != null)
        {
            byte[] fileData = Convert.FromBase64String(GameManager.assets[piece.texture]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Material material = new Material(Shader.Find("Standard"));
            material.mainTexture = texture;
            transform.GetChild(0).GetComponent<Renderer>().material = material;
            transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 1);
            transform.GetChild(0).GetComponent<MeshRenderer>().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
            transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_SpecularHighlights", 0f);
        }
    }

    int prevPosX;
    int prevPosY;
    string prevColor;
    string prevTexture;

    public override void UpdateElement()
    {
        if (!piece.real)
            return;

        if (piece.route.Count != 0)
            piece.Step(0);

        if (piece.posX != prevPosX || piece.posY != prevPosY)
        {
            transform.SetParent(GameObject.Find("Tile" + piece.posX.ToString() + "_" + piece.posY.ToString()).transform);
            prevPosX = piece.posX;
            prevPosY = piece.posY;
        }
        HandleMultiplePieces();

        if (piece.color != null && piece.color != prevColor)
        {
            Color temp;
            ColorUtility.TryParseHtmlString(piece.color, out temp);
            transform.GetComponent<Renderer>().material.color = temp;
            if (piece.texture == null)
            {
                transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            }
            prevColor = piece.color;
        }

        if (piece.texture != null && piece.texture != prevTexture)
        {
            byte[] fileData = Convert.FromBase64String(GameManager.assets[piece.texture]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
            Material material = new Material(Shader.Find("Standard"));
            material.mainTexture = texture;
            transform.GetChild(0).GetComponent<Renderer>().material = material;
            transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Glossiness", 1);
            transform.GetChild(0).GetComponent<MeshRenderer>().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
            transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_SpecularHighlights", 0f);
            prevTexture = piece.texture;
        }
    }
    void OnMouseUp()
    {
        StartCoroutine(GameObject.Find("Manager").GetComponent<GameManager>().StateMachine(this));
    }

    void HandleMultiplePieces()
    {
        int childCount=0;
        for(int i = 6; i < transform.parent.childCount; i++)
            if(transform.parent.GetChild(i).gameObject.activeSelf)
                childCount++;

        switch (childCount)
        {
            case 1:
                transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
                transform.localScale = new Vector3(0.8f, transform.localScale.y, 0.8f);
                break;
            case 2:
                transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.localPosition = new Vector3(transform.localScale.x / 2, transform.localPosition.y, 0);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localPosition = new Vector3(-transform.localScale.x / 2, transform.localPosition.y, 0);
                break;
            case 3:
                transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.localPosition = new Vector3(transform.localScale.x / 2, transform.localPosition.y, -transform.localScale.z / 2);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localPosition = new Vector3(-transform.localScale.x / 2, transform.localPosition.y, -transform.localScale.z / 2);
                transform.parent.GetChild(transform.parent.childCount - 2).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 2).transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localScale.z / 2);
                break;
            case 4:
                transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.localPosition = new Vector3(transform.localScale.x / 2, transform.localPosition.y, -transform.localScale.z / 2);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 1).transform.localPosition = new Vector3(-transform.localScale.x / 2, transform.localPosition.y, -transform.localScale.z / 2);
                transform.parent.GetChild(transform.parent.childCount - 2).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 2).transform.localPosition = new Vector3(transform.localScale.x / 2, transform.localPosition.y, transform.localScale.z / 2);
                transform.parent.GetChild(transform.parent.childCount - 3).transform.localScale = new Vector3(1.0f / 2, transform.localScale.y, 1.0f / 2);
                transform.parent.GetChild(transform.parent.childCount - 3).transform.localPosition = new Vector3(-transform.localScale.x / 2, transform.localPosition.y, transform.localScale.z / 2);
                break;
        }

    }
}
