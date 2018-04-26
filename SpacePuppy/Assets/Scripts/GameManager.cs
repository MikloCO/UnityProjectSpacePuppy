using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private ScoreManager theScoreManager;


	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Nedan är till för att när spelet startas om så
	//kommer highscore att inte klättra förens man nått det med
	//sina current poäng. 
/*	public IEnumerator RestartGameCo() {
		theScoreManager.scoreIncreasing = false;


		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	} */
}
