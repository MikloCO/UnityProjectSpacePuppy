using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:50 fr https://www.youtube.com/watch?v=FaX4B_FMPIg

public class PickUpPoints : MonoBehaviour {
    
	private ScoreManager scoreManager;
    private AudioSource myAudioSource;
    public AudioClip crackers;

    void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("DogCracker")) 
		{	//takes current points and adds the dogbones bonus points. 
			scoreManager.BoneScore();
            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
            myAudioSource.PlayOneShot(crackers, 0.5f);
            Destroy (other.gameObject);
        }
    } 
}
