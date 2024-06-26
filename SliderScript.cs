using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderValueText;

    public static int value = 3;

    // Start is called before the first frame update
    void Start() {
        _slider.onValueChanged.AddListener((v) => {
            _sliderValueText.text = v.ToString("0");
            value = (int)v;
        });
    }
}
