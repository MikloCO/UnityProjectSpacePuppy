using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public bool paused = false;

    public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		//Ersätt med detltatime
		scoreCount += pointsPerSecond * Time.deltaTime;

        if (scoreCount > hiScoreCount) {
            hiScoreCount = scoreCount;
        }

        if (paused){
            scoreCount += 0f;
        }

		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
	}
}
