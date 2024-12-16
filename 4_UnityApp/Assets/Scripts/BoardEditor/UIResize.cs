using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIResize : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rt;
    public int cornerID;
    // Start is called before the first frame update
    void Start()
    {
        rt = transform.parent.transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData _EventData)
    {

    }

    public void OnDrag(PointerEventData _EventData)
    {
        switch (cornerID)
        {
            case 0:
                rt.sizeDelta += _EventData.delta;
                rt.anchoredPosition += _EventData.delta / 2;
                break;
            case 1:
                rt.sizeDelta = new Vector2(rt.sizeDelta.x -_EventData.delta.x, rt.sizeDelta.y + _EventData.delta.y);
                rt.anchoredPosition += _EventData.delta / 2;
                break;
            case 2:
                rt.sizeDelta -= _EventData.delta;
                rt.anchoredPosition += _EventData.delta / 2;
                break;
            case 3:
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + _EventData.delta.x, rt.sizeDelta.y - _EventData.delta.y);
                rt.anchoredPosition += _EventData.delta / 2;
                break;
        }
    }

    public void OnEndDrag(PointerEventData _EventData)
    {

    }

    public Texture2D cursor;
    public void OnPointerEnter(PointerEventData _EventData)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
    public void OnPointerExit(PointerEventData _EventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
