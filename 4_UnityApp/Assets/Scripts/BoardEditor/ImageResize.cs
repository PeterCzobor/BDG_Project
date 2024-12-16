using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageResize : MonoBehaviour
{
    RectTransform rt;
    RectTransform rtPlane;
    public int cornerID;
    // Start is called before the first frame update
    void Start()
    {
        /*rt = GetComponent<RectTransform>();
        rtPlane = transform.parent.GetChild(0).GetComponent<RectTransform>();*/
    }

    // Update is called once per frame
    void Update()
    {
        switch(cornerID)
        {
            case 0:
                transform.localPosition = new Vector3(
                    transform.parent.GetChild(0).localScale.x * 5.0f+0.05f, 
                    0.26f,
                    transform.parent.GetChild(0).localScale.z * 5.0f + 0.05f);
                break;
            case 1:
                transform.localPosition = new Vector3(
                    -transform.parent.GetChild(0).localScale.x * 5.0f - 0.05f,
                    0.26f,
                    transform.parent.GetChild(0).localScale.z * 5.0f + 0.05f);
                break;
            case 2:
                transform.localPosition = new Vector3(
                    transform.parent.GetChild(0).localScale.x * 5.0f + 0.05f,
                    0.26f,
                    -transform.parent.GetChild(0).localScale.z * 5.0f - 0.05f);
                break;
            case 3:
                transform.localPosition = new Vector3(
                    -transform.parent.GetChild(0).localScale.x * 5.0f - 0.05f,
                    0.26f,
                    -transform.parent.GetChild(0).localScale.z * 5.0f - 0.05f);
                break;
        }
        
    }

    Vector3 screenPoint;
    Vector3 offset;
    Vector3 prevsize;
    float aspectRatio;
    void OnMouseDown()
    {
        aspectRatio = transform.parent.GetChild(0).localScale.x / transform.parent.GetChild(0).localScale.z;
        prevsize = transform.parent.GetChild(0).localScale;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.parent.GetChild(0).localScale - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if (Input.GetKey(KeyCode.LeftShift))
            transform.parent.GetChild(0).localScale = new Vector3(transform.parent.GetChild(0).localScale.z *aspectRatio, transform.parent.GetChild(0).localScale.y, prevsize.z + curPosition.z *0.1f);
        else
            transform.parent.GetChild(0).localScale = new Vector3(prevsize.x + curPosition.x * 0.1f, transform.parent.GetChild(0).localScale.y, prevsize.z + curPosition.z * 0.1f * aspectRatio);
    }
}
