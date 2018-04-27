﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:50 fr https://www.youtube.com/watch?v=FaX4B_FMPIg

public class PickUpPoints : MonoBehaviour {

	public int scoreToGive;

	private ScoreManager theScoreManager;

	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();		
	}
	
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
	//Döp hunden i hierarkin till Player
		if (other.gameObject.name == "Player") 
		{	//takes current points and adds the dogbones bonus points. 
			theScoreManager.scoreCount += scoreToGive;
		}
	}
}