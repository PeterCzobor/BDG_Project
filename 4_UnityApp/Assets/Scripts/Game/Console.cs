using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private bool direction = false;  // Track which animation is currently playing
    public GameObject rowTemplate;
    public List<GameObject> rows = new List<GameObject>();
    public GameObject TableBody;
    public GameObject ScrollBody;

    int number = 0;

    void Start()
    {
        //ClearLog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayLog(string message, bool error, int line)
    {
        number++;
        GameObject temp = Instantiate(rowTemplate, rowTemplate.transform.parent);
        temp.SetActive(true);
        temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -60 + rows.Count * -40, 0);
        if(error)
        {
            temp.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.red;
            temp.transform.GetChild(1).GetComponent<TMP_Text>().color = Color.red;
            temp.transform.GetChild(2).GetComponent<TMP_Text>().color = Color.red;
        }
        temp.transform.GetChild(0).GetComponent<TMP_Text>().text = number.ToString();
        temp.transform.GetChild(1).GetComponent<TMP_Text>().text = System.DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        temp.transform.GetChild(2).GetComponent<TMP_Text>().text = "[" + line + "] " + message;
        rows.Add(temp);

        if(ScrollBody.GetComponent<RectTransform>().rect.height + temp.GetComponent<RectTransform>().anchoredPosition.y - 50 < 0)
        {
            ScrollBody.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
            TableBody.GetComponent<RectTransform>().offsetMin = new Vector2(TableBody.GetComponent<RectTransform>().offsetMin.x,
                ScrollBody.GetComponent<RectTransform>().rect.height + temp.GetComponent<RectTransform>().anchoredPosition.y - 50);
        }
    }

    public void ClearLog()
    {
        number = 0;
        foreach (var row in rows)
        {
            Destroy(row);
        }
        rows.Clear();
    }

    // This function should be linked to the Button's OnClick event
    public void ShowHide()
    {
        CameraManager.SetCamera(direction);

        direction = !direction;
        GetComponent<Animator>().SetBool("Direction", direction);
    }

}
