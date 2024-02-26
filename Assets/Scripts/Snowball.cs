using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {

	public GameObject splatter;	

	// Use this for initialization
	void Start () {

		//TODO: Add an impulse force to the snowball to simulate a throwing action
		GetComponent<Rigidbody> ().AddForce (transform.forward * 20, ForceMode.Impulse);
		//TODO: Add an auto-destroy mechanism to destroy the snowball after a few seconds
		//Destroy (gameObject, 5);
		
	}

	void OnCollisionEnter(Collision collision)
	{
		//TODO: Destroy gameobject in case of collision
		//Destroy(gameObject);

		if (collision.gameObject.name == "Rigidbody Log") {

			collision.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			collision.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		} else {


		}

		//TODO: Create a snow splatter effect
		GameObject s = Instantiate (splatter, transform.position, transform.rotation);
		Destroy (s, 3);
		Destroy (gameObject);
	}
}
