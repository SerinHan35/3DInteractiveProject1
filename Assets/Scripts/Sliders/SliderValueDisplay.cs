
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueDisplay : MonoBehaviour
{
    public TMP_Text valueText;
    public string numberFormat = "0.0";
    void Start()
    {
        Slider slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(value =>
            valueText.text = value.ToString(numberFormat));

        valueText.text = slider.value.ToString(numberFormat);
    }
}
