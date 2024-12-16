using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI Skin", menuName = "MyAssets/DialogBox/UI Skin", order = 111)]
public class DialogSkin : ScriptableObject
{
    private int m_version = 0;
    public int Version { get { return m_version; } }

    [ContextMenu("Refresh UI")]
    private void Invalidate()
    {
        m_version = UnityEngine.Random.Range(int.MinValue / 2, int.MaxValue / 2);
    }

#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        // Refresh all UIs that use this skin
        Invalidate();
    }
#endif

    [Header("General")]
    [SerializeField]
    private TMP_FontAsset m_font;
    public TMP_FontAsset Font
    {
        get { return m_font; }
        set { if (m_font != value) { m_font = value; m_version++; } }
    }

    [Header("Dialog Box Window")]
    [SerializeField]
    private Color m_backgroundColor = Color.grey;
    public Color BackgroundColor
    {
        get { return m_backgroundColor; }
        set { if (m_backgroundColor != value) { m_backgroundColor = value; m_version++; } }
    }

    [SerializeField]
    private Color m_windowColor = Color.black;
    public Color WindowColor
    {
        get { return m_windowColor; }
        set { if (m_windowColor != value) { m_windowColor = value; m_version++; } }
    }

    [SerializeField]
    private Color m_mainTextColor = Color.white;
    public Color MainTextColor
    {
        get { return m_mainTextColor; }
        set { if (m_mainTextColor != value) { m_mainTextColor = value; m_version++; } }
    }

    [Header("Buttons")]
    [SerializeField]
    private Color m_buttonColor = Color.white;
    public Color ButtonColor
    {
        get { return m_buttonColor; }
        set { if (m_buttonColor != value) { m_buttonColor = value; m_version++; } }
    }

    [SerializeField]
    private Color m_buttonHighlightColor = Color.white;
    public Color ButtonHighlightColor
    {
        get { return m_buttonHighlightColor; }
        set { if (m_buttonHighlightColor != value) { m_buttonHighlightColor = value; m_version++; } }
    }

    [SerializeField]
    private Color m_buttonPressedColor = Color.white;
    public Color ButtonPressedColor
    {
        get { return m_buttonPressedColor; }
        set { if (m_buttonPressedColor != value) { m_buttonPressedColor = value; m_version++; } }
    }

    [SerializeField]
    private Color m_buttonTextColor = Color.black;
    public Color ButtonTextColor
    {
        get { return m_buttonTextColor; }
        set { if (m_buttonTextColor != value) { m_buttonTextColor = value; m_version++; } }
    }

    [SerializeField]
    private Sprite m_buttonBackground;
    public Sprite ButtonBackground
    {
        get { return m_buttonBackground; }
        set { if (m_buttonBackground != value) { m_buttonBackground = value; m_version++; } }
    }

    public void ApplyTo(TMP_Text text, Color textColor)
    {
        text.color = textColor;
        text.font = m_font;
        //text.fontSize = m_fontSize;
    }

    public void ApplyTo(Button button)
    {
        button.image.color = Color.white;
        var colors = button.colors;
        colors.normalColor = m_buttonColor;
        colors.highlightedColor = m_buttonHighlightColor;
        colors.pressedColor = m_buttonPressedColor;
        button.colors = colors;
        button.image.sprite = m_buttonBackground;

        ApplyTo(button.GetComponentInChildren<TMP_Text>(), m_buttonTextColor);
    }
}
