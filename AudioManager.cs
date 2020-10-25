using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string firstPlay = "First Play";
    private static readonly string volumePref = "Volume Pref";
    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;
    public AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);
        if(firstPlayInt == 0)
        {
            volumeFloat = 0.50f;
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(volumePref, volumeFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(volumePref);
            volumeSlider.value = volumeFloat;
        }
    }

    public void SaveSound()
    {
        PlayerPrefs.SetFloat(volumePref, volumeSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSound();
        }
    }

    private void OnDisable()
    {
        SaveSound();
    }
    public void UpdateSound()
    {
        gameAudio.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
