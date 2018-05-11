using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour {
	//Alla texter och floats och bools e deklaraerade nedan

	public Pause pause;
	public bool paused = false;
	public Text scoreText;
	public Text hiScoreText;
	public float scoreCount;
	public int hiScoreCount;
	public int pointsPerSecond;

	


    // ******************************* OLIVIAS IDE TILL EN LÖSNING *******************************************************************************

	public void scoreVsHighScore()
    {
		Debug.Log (scoreCount);
		if (PlayerPrefs.GetInt ("highscore") < (int)scoreCount) {
			PlayerPrefs.SetInt ("highscore", (int)scoreCount);
		}
        //storeTopTenHighScore();

    }

    public void storeTopTenHighScore()
    {

    }
    //*********************** OLIVIAS IDE TILL EN LÖSNING ***********************************************************************************
    // **************************************************************//
	/* START OCH UPDATE */


	void Start () {
		Debug.Log(PlayerPrefs.GetInt("highscore"));
		DontDestroyOnLoad (gameObject);
		scoreVsHighScore();
		//LoadGameData ();
		//LoadPlayerProgress ();
		scoreCount = 0;
		hiScoreCount = PlayerPrefs.GetInt ("highscore");
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);


        //Gör kod som visar högsta highscore som funnts, och den börjar inte räkna upp förens man nått den

        }


	void Update () {
		if (!paused) {
			
			//Ersätt med detltatime
			scoreCount += pointsPerSecond * Time.deltaTime * pause.gameSpeed; //ändra t gamespeed

            // John vill add crack 

			scoreText.text = "Score: " + Mathf.Round (scoreCount);

            //När man dör så kollar den om highscore än större än score. Om ja: lagra nytt highScore.
		}
	}
	


	
}