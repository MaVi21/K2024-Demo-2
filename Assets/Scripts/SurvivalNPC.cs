using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class SurvivalNPC : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private AudioClip audioClip;
    public bool oneShot = true;
    public AudioMixerGroup mixerGroup;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixerGroup;

        audioClip = (AudioClip)Resources.Load("SighAudio");
        audioSource.clip = audioClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger sigh");
            animator.SetTrigger("Sigh");

            if (oneShot)
            {
                Destroy(GetComponent<BoxCollider>());                
            }
        }
    }

    void PlaySighAudio()
    {
        audioSource.Play();   
    }
}
