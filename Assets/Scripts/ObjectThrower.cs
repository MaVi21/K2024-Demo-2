using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ObjectThrower : MonoBehaviour {

	public Rigidbody snowball;
    [SerializeField] private AudioClip throwClip;
    [SerializeField] private TempAudioPlayer tempAudioPlayer;
    [SerializeField] private AudioMixerGroup mixerGroup;
    [SerializeField] private float fireCooldown = 3f; // Adjustable cooldown period between firing inputs
    [SerializeField] private bool canThrow = true; // Flag to track if the weapon can fire

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1") && canThrow){

			Debug.Log ("Throw snowball");
			Instantiate(snowball, transform.position, transform.rotation);
            TempAudioPlayer clone;
            clone = Instantiate(tempAudioPlayer, transform.position, transform.rotation);
            clone.PlayAudioClip(throwClip, mixerGroup);

            StartCoroutine(ThrowCooldown());
        }		
	}

    IEnumerator ThrowCooldown()
    {
        canThrow = false;
        yield return new WaitForSeconds(fireCooldown);
        canThrow = true;
    }
}
