using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageElement : GameElement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider>().size=new Vector3(transform.GetChild(0).localScale.x*10, 0.1f, transform.GetChild(0).localScale.z*10);
    }
    private Vector3 screenPoint;
    private Vector3 offset;
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(curPosition.x, transform.position.y, curPosition.z); // Lock z-coordinate
    }
}
