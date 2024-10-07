using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderActivity : MonoBehaviour
{
    [SerializeField] String _volumeParameter = "Main";
    [SerializeField] AudioMixer _mixer;
    private Slider _slider;
    
    private float _volumeValue;
    private const float _multiplier = 20f; 
    private const float _minVolumeDB = -80f;

    void Awake() {
        _slider = GetComponent<Slider>();

        _volumeValue = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_slider.value) * _multiplier);
        
        _slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
        
        _mixer.SetFloat(_volumeParameter, _volumeValue);

        _slider.onValueChanged.AddListener(HandlSliderValueChanged);
    }

    private void HandlSliderValueChanged(float value) {
        if (value <= 0) {
            _volumeValue = _minVolumeDB;
        } else {
            _volumeValue = Mathf.Log10(value) * _multiplier;
        }
        _mixer.SetFloat(_volumeParameter, _volumeValue);
        
        PlayerPrefs.SetFloat(_volumeParameter, _volumeValue);
    }
}
