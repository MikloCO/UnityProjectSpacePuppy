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
    public int pointsPerSecond = 5;
    public int pointsPerSwipePart = 10;
    public int pointsPerBone = 20;
    public int speedMultiplier = 2;
    public int perfectMultiplier = 2;
    
    public void ScoreVsHighScore () {
        if (PlayerPrefs.GetInt("highscore") < (int)scoreCount) {
            PlayerPrefs.SetInt("highscore", (int)scoreCount);
        }
    }
    
    public void SwipeScore (int points, bool perfect) {
        int pointsToAdd = points * pointsPerSwipePart * pause.scoreSpeed * speedMultiplier;
        if (perfect) {
            pointsToAdd *= perfectMultiplier;
        }
        scoreCount += pointsToAdd;
    }

    public void BoneScore() {
        scoreCount += pointsPerBone * pause.scoreSpeed * speedMultiplier;
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
        ScoreVsHighScore();
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt("highscore");
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
    }

    void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime *  pause.gameSpeed * pause.scoreSpeed * speedMultiplier;

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}