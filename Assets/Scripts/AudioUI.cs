using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioUI : MonoBehaviour
{
    public AudioMixer mixer;

    public void setEffectsVolume(float vol)
    {
        Debug.Log("Volume: " + vol);
        mixer.SetFloat("effectsVolume", vol);
    }

}
