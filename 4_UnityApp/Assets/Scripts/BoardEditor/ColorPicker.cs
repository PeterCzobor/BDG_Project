using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Slider RSlider;
    public Slider GSlider;
    public Slider BSlider;
    public Slider ASlider;

    public TMP_Text RValue;
    public TMP_Text GValue;
    public TMP_Text BValue;
    public TMP_Text AValue;

    public TMP_InputField HexValue;

    Action<Color> action;

    private bool ignoreEvent = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Color color, Action<Color> action)
    {
        this.action = action;

        ignoreEvent = true;
        UpdateSliders(color);
        UpdateHexInput();
        ignoreEvent = false;
    }

    public void OnSliderValueChanged()
    {
        if (ignoreEvent) return;

        ignoreEvent = true;
        UpdateHexInput();
        ignoreEvent = false;
        RValue.text = RSlider.value.ToString();
        GValue.text = GSlider.value.ToString();
        BValue.text = BSlider.value.ToString();
        AValue.text = ASlider.value.ToString();
        action(new Color(
                RSlider.value / 255,
                GSlider.value / 255,
                BSlider.value / 255,
                ASlider.value / 255));
    }

    public void OnHexInputChanged()
    {
        if (ignoreEvent) return;

        if (ColorUtility.TryParseHtmlString("#" + HexValue.text, out Color color))
        {
            ignoreEvent = true;
            UpdateSliders(color);
            ignoreEvent = false;
        }
        action(color);
    }

    private void UpdateHexInput()
    {
        Color color = new Color(
                RSlider.value / 255,
                GSlider.value / 255,
                BSlider.value / 255,
                ASlider.value / 255);
        HexValue.text = ColorUtility.ToHtmlStringRGB(color);
    }

    private void UpdateSliders(Color color)
    {
        RSlider.value = color.r * 255;
        GSlider.value = color.g * 255;
        BSlider.value = color.b * 255;
        ASlider.value = color.a * 255;
        RValue.text = RSlider.value.ToString();
        GValue.text = GSlider.value.ToString();
        BValue.text = BSlider.value.ToString();
        AValue.text = ASlider.value.ToString();
    }
}
