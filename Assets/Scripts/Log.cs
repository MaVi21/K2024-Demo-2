using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Log : MonoBehaviour {

	[SerializeField] private AudioClip pickClip;
	[SerializeField] private TempAudioPlayer tempAudioPlayer;
    [SerializeField] private AudioMixerGroup mixerGroup;

    void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag == "Player")
        {
            GameObject.Find("Inventory").SendMessage("PickLog");

            TempAudioPlayer clone;
            clone = Instantiate(tempAudioPlayer, transform.position, transform.rotation);
            clone.PlayAudioClip(this.pickClip, mixerGroup);
            Destroy(gameObject);
        }    

	}

}
