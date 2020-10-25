using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string firstPlay = "First Play";
    private static readonly string volumePref = "Volume Pref";
    private float volumeFloat;
    public AudioSource gameAudio;

    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        volumeFloat = PlayerPrefs.GetFloat(volumePref);
        gameAudio.volume = volumeFloat;
    }
}
