using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCD : MonoBehaviour {
	public AudioClip[] clips;
	void Start () {	
	}

	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("CD")) 
		{
			AudioClip clip;
			do {
				clip = clips [Random.Range (0, clips.Length)];
			} while(clip.Equals(Camera.main.GetComponent<AudioSource> ().clip));

            Camera.main.GetComponent<AudioSource> ().clip = clip;
			Camera.main.GetComponent<AudioSource> ().Play ();
			Destroy (other.gameObject);
		}
	}
}
