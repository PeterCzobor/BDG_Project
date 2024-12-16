using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIElement : GameElement, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rt;

    bool hasFocus = false;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !hasFocus && Input.GetMouseButtonDown(0))
        {
            active = false;
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            EditorManager.selectedUI = null;
        }
    }

    bool drag = false;
    public void OnBeginDrag(PointerEventData _EventData)
    {
        drag = true;
    }

    public void OnDrag(PointerEventData _EventData)
    {
        if(active)
            rt.anchoredPosition += _EventData.delta;
    }

    public void OnEndDrag(PointerEventData _EventData)
    {
        drag = false;
    }

    bool active= false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!active && !drag && SceneManager.GetActiveScene().name == "BoardEditor")
        {
            active = true;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            EditorManager.selectedUI = gameObject;
        }
        else if (!drag)
        {
            active = false;
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            EditorManager.selectedUI = null;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasFocus = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hasFocus = true;
    }
    public void OverEditButton()
    {
        hasFocus = true;
    }
    public void NotOverEditButton()
    {
        hasFocus = false;
    }
}
