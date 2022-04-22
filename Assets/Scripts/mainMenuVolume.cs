using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class mainMenuVolume : MonoBehaviour
{
    public AudioMixer mainMenuAudio;

    public void setVolume(float sliderValue)
    {
        mainMenuAudio.SetFloat("mainMenuVolume", Mathf.Log10(sliderValue) * 20);
    }

}
