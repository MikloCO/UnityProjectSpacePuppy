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
    public int speedMultiplier = 1;
    
    public void ScoreVsHighScore () {
        if (PlayerPrefs.GetInt("highscore") < (int)scoreCount) {
            PlayerPrefs.SetInt("highscore", (int)scoreCount);
        }
    }
    
    public void SwipeScore (int points, bool perfect) {
        int pointsToAdd = points * speedMultiplier;
        if (perfect) {
            pointsToAdd *= 2;
        }
        scoreCount += pointsToAdd;
    }

    public void BoneScore() {
        scoreCount += pointsPerBone * speedMultiplier;
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
        ScoreVsHighScore();
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt("highscore");
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
    }

    void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime * pause.gameSpeed * speedMultiplier;

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}