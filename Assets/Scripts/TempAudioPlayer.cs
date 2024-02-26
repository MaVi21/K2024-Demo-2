using UnityEngine;
using UnityEngine.Audio;

public class TempAudioPlayer : MonoBehaviour
{
  
    public void PlayAudioClip(AudioClip audioClip, AudioMixerGroup mixerGroup)
    {

        // Add an AudioSource component to the GameObject
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // Set the AudioClip to be played
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = mixerGroup;

        // Play the audio clip
        audioSource.Play();

        // Destroy the GameObject after the audio clip finishes playing
        Destroy(gameObject, audioClip.length);
    }
}