using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0.26f, transform.parent.GetChild(0).localScale.z * 5.0f + 0.1f);
    }

    private Vector3 screenPoint;
    private Vector3 offset;
    float prevangle;
    void OnMouseDown()
    {
        prevangle = transform.parent.eulerAngles.y;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.parent.eulerAngles - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.parent.eulerAngles = new Vector3(0, prevangle+curPosition.x*10.0f, 0); // Lock z-coordinate
    }
}
