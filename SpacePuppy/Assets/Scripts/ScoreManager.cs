using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour {
	//Alla texter och floats och bools e deklaraerade nedan
	public bool paused = false;
	public Text scoreText;
	public Text hiScoreText;
	public float scoreCount;
	public float hiScoreCount;
	public float pointsPerSecond;
	private int playerScore;
	public int highestScore = 0;
    public Text highScoreText;
    public int myScore;
    public float speed;

	


    // ******************************* OLIVIAS IDE TILL EN LÖSNING *******************************************************************************

	public void scoreVsHighScore()
    {

		if (PlayerPrefs.GetInt ("highscore") > playerScore) {
			PlayerPrefs.SetInt ("highscore", playerScore);
		}


		highScoreText.text = "Highscore är: " + PlayerPrefs.GetInt ("highscore");
        storeTopTenHighScore();

    }

    public void isPlayerDead()
    {
        //Om spelaren är i spelläget (inte swipen), och hastigheten är 0 eller mindre: gör jämföringen scoreVsHighScore
        if (GameObject.FindWithTag("Player").Equals(speed == 0))
        {

            scoreVsHighScore();
        }
        else
            return;

    }

    public void storeTopTenHighScore()
    {

    }
    //*********************** OLIVIAS IDE TILL EN LÖSNING ***********************************************************************************
    // **************************************************************//
	/* START OCH UPDATE */


	void Start () {
		DontDestroyOnLoad (gameObject);
		LoadGameData ();
		LoadPlayerProgress ();
		playerScore = 0;

        //Gör kod som visar högsta highscore som funnts, och den börjar inte räkna upp förens man nått den

        }


	void Update () {
		if (!paused) {
			
			//Ersätt med detltatime
			scoreCount += pointsPerSecond * Time.deltaTime; //ändra t gamespeed

            // John vill add crack 

			scoreText.text = "Score: " + Mathf.Round (scoreCount);
			hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);

            isPlayerDead();

            //När man dör så kollar den om highscore än större än score. Om ja: lagra nytt highScore.
		}
	}
	


	
}