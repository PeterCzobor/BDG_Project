using Assets.Language;
using Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Variables : MonoBehaviour
{
    private bool direction = false;  // Track which animation is currently playing
    public GameObject rowTemplate;
    public List<VariableInfo> rows = new List<VariableInfo>();
    public GameObject TableBody;
    public GameObject ScrollBody;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVariables()
    {
        foreach (var row in rows)
        {
            Destroy(row.row);
        }
        rows.Clear();
        ScrollBody.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        foreach (var kvp in GameManager.visitor.Variables)
        {
            AddVariable(kvp);
        }
    }

    void AddVariable(KeyValuePair<string, object> kvp)
    {
        if (kvp.Value != null && kvp.Value.GetType() != typeof(Tile))
        {
            GameObject temp = Instantiate(rowTemplate, rowTemplate.transform.parent);
            temp.SetActive(true);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -30 + rows.Count * -40, 0);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = kvp.Key;
            if(kvp.Value is IList list && list.Count>0)
                temp.transform.GetChild(1).GetComponent<TMP_Text>().text = "List [" + list[0].ToString() + "]";
            else
                temp.transform.GetChild(1).GetComponent<TMP_Text>().text = kvp.Value.ToString();
            rows.Add(new VariableInfo(temp, kvp));

            if (ScrollBody.GetComponent<RectTransform>().rect.height + temp.GetComponent<RectTransform>().anchoredPosition.y - 50 < 0)
            {
                TableBody.GetComponent<RectTransform>().offsetMin = new Vector2(TableBody.GetComponent<RectTransform>().offsetMin.x,
                    ScrollBody.GetComponent<RectTransform>().rect.height + temp.GetComponent<RectTransform>().anchoredPosition.y - 50);
            }
        }
    }

    public GameObject MoreInfo;
    public TMP_Text Header;
    public TMP_Text Key;
    public TMP_Text Value;
    public GameObject DetailsTemplate;
    public List<VariableInfo> DetailsRows = new List<VariableInfo>();


    public void VariableClicked(GameObject gameObject)
    {
        VariableInfo variableInfo = null;
        foreach (var row in rows)
        {
            if(row.row == gameObject)
            {
                variableInfo = row;
                break;
            }
        }
        if(variableInfo == null)
        {
            foreach (var row in DetailsRows)
            {
                if (row.row == gameObject)
                {
                    variableInfo = row;
                    break;
                }
            }
        }
        foreach (var row in DetailsRows)
        {
            Destroy(row.row);
        }
        DetailsRows.Clear();

        MoreInfo.SetActive(true);
        Header.text = variableInfo.kvp.Key;
        Key.text = variableInfo.kvp.Key;
        if (variableInfo.kvp.Value is IList _list)
            Value.text = "List [" + _list[0].ToString() + "]";
        else
            Value.text = variableInfo.kvp.Value.ToString();
        MoreInfo.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 200);
        if (variableInfo.kvp.Value is ComplexVar cv)
        {
            MoreInfo.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 220 + cv.GetDetails().Count * 40);
            foreach (var col in cv.GetDetails())
            {
                GameObject temp = Instantiate(DetailsTemplate, DetailsTemplate.transform.parent);
                temp.SetActive(true);
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200 + DetailsRows.Count * -40, 0);
                temp.transform.GetChild(0).GetComponent<TMP_Text>().text = col.Key;
                if (col.Value is IList list_)
                    temp.transform.GetChild(1).GetComponent<TMP_Text>().text = "List [" + list_[0].ToString() + "]";
                else
                    temp.transform.GetChild(1).GetComponent<TMP_Text>().text = col.Value.ToString();
                if (!(col.Value is ComplexVar || col.Value is IList))
                {
                    temp.GetComponent<Button>().enabled = false;
                }
                DetailsRows.Add(new VariableInfo(temp, col));
            }
        }
        if (variableInfo.kvp.Value is IList list)
        {
            MoreInfo.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 220 + list.Count * 40);
            foreach (var item in list)
            {
                var key = GameManager.visitor.Variables.FirstOrDefault(x => x.Value == item).Key;
                GameObject temp = Instantiate(DetailsTemplate, DetailsTemplate.transform.parent);
                temp.SetActive(true);
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200 + DetailsRows.Count * -40, 0);
                temp.transform.GetChild(0).GetComponent<TMP_Text>().text = key;
                if (item is IList list_)
                    temp.transform.GetChild(1).GetComponent<TMP_Text>().text = "List [" + list_[0].ToString() + "]";
                else
                    temp.transform.GetChild(1).GetComponent<TMP_Text>().text = item.ToString();
                if (!(item is ComplexVar || item is IList))
                {
                    temp.GetComponent<Button>().enabled = false;
                }
                DetailsRows.Add(new VariableInfo(temp, new KeyValuePair<string, object>(key, item)));
            }
        }
    }

    public void CloseMoreInfo()
    {
        MoreInfo.SetActive(false);
    }

    // This function should be linked to the Button's OnClick event
    public void ShowHide()
    {
        CameraManager.SetZoom(direction);

        direction = !direction;
        GetComponent<Animator>().SetBool("Direction", direction);
    }
}

public class VariableInfo
{
    public GameObject row;
    public KeyValuePair<string, object> kvp;

    public VariableInfo(GameObject row, KeyValuePair<string, object> kvp)
    {
        this.row = row;
        this.kvp = kvp;
    }
}
