using Language;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual string VariableKey
    {
        get { return null; }
        set {  }
    }
    public virtual object VariableObject
    {
        get { return null; }
        set { }
    }

    public virtual void CreateElement(object[] args)
    {
        
    }

    public virtual void CopyElement(object other)
    {
        
    }

    public virtual void UpdateElement()
    {
        
    }
}
