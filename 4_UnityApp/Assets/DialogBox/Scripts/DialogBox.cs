using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    private static DialogBox m_instance = null;
    private static DialogBox Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = Instantiate(Resources.Load<GameObject>("DialogBoxCanvas")).GetComponent<DialogBox>();
                DontDestroyOnLoad(m_instance.gameObject);
                m_instance.gameObject.SetActive(false);
            }

            return m_instance;
        }
    }
    private int m_skinVersion = 0;

    [SerializeField]
    private DialogSkin m_skin;

    public static DialogSkin Skin
    {
        get { return Instance.m_skin; }
        set
        {
            if (value && Instance.m_skin != value)
            {
                Instance.m_skin = value;
                Instance.m_skinVersion = Instance.m_skin.Version;
                Instance.RefreshSkin();
            }
        }
    }

    public Image background;
    public Image window;
    public TMP_Text mainText;
    public Button buttonA;
    public Button buttonB;
    public TMP_Text textA;
    public TMP_Text textB;

    public static int Result { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static IEnumerator ShowDialog(string mainText, string optionA, string optionB)
    {
        Instance.RefreshSkin();
        Instance.gameObject.SetActive(true);
        Instance.mainText.text = mainText;
        Instance.buttonA.gameObject.SetActive(true);
        Instance.buttonB.gameObject.SetActive(true);
        Instance.textA.text = optionA;
        Instance.textB.text = optionB;

        while (Instance.gameObject.activeSelf)
            yield return null;
    }

    public static IEnumerator ShowDialog(string mainText, string option)
    {
        Instance.RefreshSkin();
        Instance.gameObject.SetActive(true);
        Instance.mainText.text = mainText;
        Instance.buttonA.gameObject.SetActive(false);
        Instance.buttonB.gameObject.SetActive(true);
        Instance.textB.text = option;

        while (Instance.gameObject.activeSelf)
            yield return null;
    }

    public void OptionA()
    {
        Result = 0;
        Instance.gameObject.SetActive(false);
    }
    public void OptionB()
    {
        Result = 1;
        Instance.gameObject.SetActive(false);
    }

    private void RefreshSkin()
    {
        background.color = m_skin.BackgroundColor;
        window.color = m_skin.WindowColor;
        mainText.color = m_skin.MainTextColor;
        m_skin.ApplyTo(buttonA);
        m_skin.ApplyTo(buttonB);
    }

}
