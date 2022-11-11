using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;
    
    public void SetVolume(float sliderValue)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 50);
    }
}
