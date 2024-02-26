using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;
using System;
using UnityEngine.UI;

public class AudioPreferences : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private void Start()
    {
        LoadVolume();
    }

    private void LoadVolume()
    {
        float volume =  PlayerPrefs.GetFloat("effectsVolume");
        audioMixer.SetFloat("effectsVolume", volume);
        volumeSlider.value = volume;
    }

    private void OnApplicationQuit()
    {
        SaveVolume();
    }

    private void OnDisable()
    {
        if (!Application.isPlaying)
        {
            SaveVolume();
        }
    }

    private void SaveVolume()
    {
        // Check if the audio mixer is assigned
        if (audioMixer == null)
        {
            Debug.LogWarning("AudioMixer is not assigned.");
            return;
        }

        // Get the volume value of the "effects" group from the AudioMixer
        float volume;
        bool result = audioMixer.GetFloat("effectsVolume", out volume);

        if (result)
        {
            // Save the volume value to PlayerPrefs
            PlayerPrefs.SetFloat("effectsVolume", volume);
            PlayerPrefs.Save();
            Debug.Log("Effects volume saved: " + volume);
        }
        else
        {
            Debug.LogWarning("Failed to get the volume value of the effects group from the AudioMixer.");
        }
    }
}
