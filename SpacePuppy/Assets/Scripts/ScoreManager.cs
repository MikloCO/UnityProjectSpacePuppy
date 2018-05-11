using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour {
    //Alla texter och floats och bools e deklaraerade nedan

    public Pause pause;
    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public int hiScoreCount;
    public int pointsPerSecond;




    // ******************************* OLIVIAS IDE TILL EN LÖSNING *******************************************************************************

    public void scoreVsHighScore () {
        if (PlayerPrefs.GetInt("highscore") < (int)scoreCount) {
            PlayerPrefs.SetInt("highscore", (int)scoreCount);
        }
        //storeTopTenHighScore();

    }

    public void storeTopTenHighScore () {

    }
    //*********************** OLIVIAS IDE TILL EN LÖSNING ***********************************************************************************
    // **************************************************************//
    /* START OCH UPDATE */


    void Start () {
        DontDestroyOnLoad(gameObject);
        scoreVsHighScore();
        //LoadGameData ();
        //LoadPlayerProgress ();
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt("highscore");
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);


        //Gör kod som visar högsta highscore som funnts, och den börjar inte räkna upp förens man nått den

    }


    void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime * pause.gameSpeed;

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}