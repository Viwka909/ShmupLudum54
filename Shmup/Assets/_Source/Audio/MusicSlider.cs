using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

[RequireComponent(typeof(Slider))]
public class MusicSlider : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    
    public AudioMixer mixer;
    [SerializeField]
 
    public string sliderName;
    public AudioData _data;
    private void Start()
    {
        slider.value = _data.Value;
        UpdateValueOnChange(slider.value);
        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }

    public void UpdateValueOnChange(float value)
    {
        if(mixer != null)
        mixer.SetFloat(sliderName, Mathf.Log(value) * 20f);
        _data.Value = slider.value;
        
    }
}
