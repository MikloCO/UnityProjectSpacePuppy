using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private ScoreManager theScoreManager;
	public Transform curvesGenerator;
	private Vector3 curvesStartPoint;
	private Movement thePlayer;

	private Vector3 playerStartPoint;


	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		curvesStartPoint = curvesGenerator.position;
		playerStartPoint = thePlayer.transform.position;

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

	public void RestartGame()
	{
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo()
	{
		thePlayer.gameObject.SetActive(false);
		yield return new WaitForSeconds (0.5f);
		thePlayer.transform.position = playerStartPoint;
		curvesGenerator.position = curvesStartPoint;
		thePlayer.gameObject.SetActive(true);
	}

}
