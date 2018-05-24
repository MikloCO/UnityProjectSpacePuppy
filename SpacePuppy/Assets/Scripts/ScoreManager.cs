using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SocialPlatforms;

public class ScoreManager : MonoBehaviour {
    //Alla texter och floats och bools e deklaraerade nedan

    private Pause pause;
    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public int hiScoreCount;
    public float pointsPerSecond = 5.0f;
    public float pointsPerSwipePart = 10.0f;
    public float pointsPerBone = 10.0f;
    public float difficultyMultiplier = 1.0f;
    public float difficultyMultiplierIncrease = 1.0f;
    public float perfectMultiplier = 3.0f;
	int [] scoreCountArr = new int[10];

    public void ScoreVsHighScore () {
		for (int i = 1; i <= 10; i++) {
			if (PlayerPrefs.GetInt ("highscore"+i) < (int)scoreCount) {
				for (int j = 10; j > i; j--) {
					PlayerPrefs.SetInt(("highscore"+(j)), PlayerPrefs.GetInt("highscore"+(j-1)));
				}
				PlayerPrefs.SetInt (("highscore"+i), (int)scoreCount);
				return;
			}
		}
    }
    
    public void SwipeScore (int points, bool perfect) {
        float pointsToAdd = points * pointsPerSwipePart * difficultyMultiplier;
        if (perfect) {
            pointsToAdd *= perfectMultiplier;
        }
        scoreCount += pointsToAdd;
    }

    public void BoneScore() {
        scoreCount += pointsPerBone * difficultyMultiplier;
    }

    void Start () {

		for (int i = 1; i <= 10; i++) {
			Debug.Log (PlayerPrefs.GetInt ("highscore" + i));
		}

        pause = FindObjectOfType<Pause>();
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt("highscore");
        hiScoreText.text = "High Score: " + (hiScoreCount);


	}

	
//	public int FinalScore() {

//	Debug.Log(BonesScore() + SwipeScore() + scoreCount());

//	for (int i = 0; i < 10; i++) {
//		new[i] = scoreCount;
//	}
//	return scoreCount;
//}
				
    void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime *  pause.gameSpeed * difficultyMultiplier;

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
	}
}