using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:50 fr https://www.youtube.com/watch?v=FaX4B_FMPIg

public class PickUpPoints : MonoBehaviour {
    
	private ScoreManager scoreManager;

	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();		
	}
	
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("DogCracker")) 
		{	//takes current points and adds the dogbones bonus points. 
			scoreManager.BoneScore();
			Destroy (other.gameObject);
		}
	}
}
