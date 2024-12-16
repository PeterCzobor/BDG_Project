using Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageObject : GameElement
{
    public Vector3 position;
    public Vector3 size;
    public float angle;

    public string ID;
    public string texture;

    public override void CreateElement(object[] args)
    {
        if (args[0] is Vector3 position_)
            position = position_;
        if (args[1] is Vector3 size_)
            size = size_;
        if (args[2] is float angle_)
            angle = angle_;
        if (args[3] is string ID_)
            ID = ID_;
        if (args[4] is string texture_)
            texture = texture_;

        transform.localPosition = position;
        transform.GetChild(0).localScale = size;
        transform.eulerAngles = new Vector3(0, angle, 0);

        byte[] fileData = Convert.FromBase64String(texture);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = tex;

        if(size == Vector3.zero)
        {
            if (tex.height >= tex.width)
                transform.GetChild(0).localScale = new Vector3(0.1f * ((float)tex.width / (float)tex.height), 0.1f, 0.1f);
            if (tex.height < tex.width)
                transform.GetChild(0).localScale = new Vector3(0.1f, 0.1f, 0.1f * ((float)tex.height / (float)tex.width));
        }
    }

    public override void CopyElement(object other)
    {
        if (other is ImageObject imageObject)
        {
            position = imageObject.position;
            size = imageObject.size;
            angle = imageObject.angle;
            ID = imageObject.ID;
            texture = imageObject.texture;
        }

        transform.localPosition = position;
        transform.GetChild(0).localScale = size;
        transform.eulerAngles = new Vector3(0, angle, 0);

        byte[] fileData = Convert.FromBase64String(texture);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);
        transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = tex;

        if (size == Vector3.zero)
        {
            if (tex.height >= tex.width)
                transform.GetChild(0).localScale = new Vector3(0.1f * ((float)tex.width / (float)tex.height), 0.1f, 0.1f);
            if (tex.height < tex.width)
                transform.GetChild(0).localScale = new Vector3(0.1f, 0.1f, 0.1f * ((float)tex.height / (float)tex.width));
        }
    }
}
