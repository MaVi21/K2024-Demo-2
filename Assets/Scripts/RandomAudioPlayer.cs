using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour {

	public AudioClip[] audioClips;
	public AudioSource audioSource;
	public int delay = 0;
	public int maxDelay = 0;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		int audioDelay = Random.Range(delay, maxDelay + 1);
		Invoke("PlayAudio", audioDelay);
	}
	
	// Update is called once per frame
	void PlayAudio () {

		int randomNumber = Random.Range (0, audioClips.Length);
		AudioClip randomClip = audioClips [randomNumber];
		audioSource.clip = randomClip;
		audioSource.Play ();
		int audioDelay = Random.Range(delay, maxDelay + 1);
		//Debug.Log("audioDelay " + audioDelay);
		Invoke ("PlayAudio", audioSource.clip.length + audioDelay);
	}
}
