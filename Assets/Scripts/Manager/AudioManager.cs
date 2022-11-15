using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _audioMixer;
    public void SetVolume(float sliderValue)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 50);
    }
}
