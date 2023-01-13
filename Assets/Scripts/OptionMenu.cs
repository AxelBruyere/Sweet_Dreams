using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private TextMeshProUGUI valueText;

    public void OnChangeSlider(float value)
    {
        //valueText.SetText($"{value.ToString("N4")}");

        mixer.SetFloat("Volume", Mathf.Log10(value)*20);
    }
}
