using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeController : MonoBehaviour
{

    public AudioMixer mixer;
    public AudioMixer soundFX;

    public void setVolume(float sliderValue)
    {
        mixer.SetFloat("volume", Mathf.Log10(sliderValue) * 20);
    }

    public void setFXvolume(float sliderValue)
    {
        soundFX.SetFloat("soundFXVolume", Mathf.Log10(sliderValue) * 20);

    }

}
