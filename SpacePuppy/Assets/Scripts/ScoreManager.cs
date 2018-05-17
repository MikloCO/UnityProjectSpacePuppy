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
    public float pointsPerSecond = 5.0f;
    public float pointsPerSwipePart = 10.0f;
    public float pointsPerBone = 10.0f;
    public float speedPointMultiplier = 1.0f;
    public float speedPointMultiplierIncrease = 1.0f;
    public float perfectMultiplier = 3.0f;
    
    public void ScoreVsHighScore () {
        if (PlayerPrefs.GetInt("highscore") < (int)scoreCount) {
            PlayerPrefs.SetInt("highscore", (int)scoreCount);
        }
    }
    
    public void SwipeScore (int points, bool perfect) {
        float pointsToAdd = points * pointsPerSwipePart * speedPointMultiplier;
        if (perfect) {
            pointsToAdd *= perfectMultiplier;
        }
        scoreCount += pointsToAdd;
    }

    public void BoneScore() {
        scoreCount += pointsPerBone * speedPointMultiplier;
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
        ScoreVsHighScore();
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt("highscore");
        hiScoreText.text = "High Score: " + (hiScoreCount);
    }

    void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime *  pause.gameSpeed * speedPointMultiplier;

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}