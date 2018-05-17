using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:50 fr https://www.youtube.com/watch?v=FaX4B_FMPIg

public class PickUpPoints : MonoBehaviour {
    
	private ScoreManager scoreManager;
    public AudioSource playerAudio;
    public AudioClip clip;

    void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
        playerAudio = GetComponent<AudioSource>();
    }
	
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("DogCracker")) 
		{	//takes current points and adds the dogbones bonus points. 
			scoreManager.BoneScore();
            other.GetComponent<AudioSource>().Play();
            Destroy (other.gameObject);
        }
    } 
}
