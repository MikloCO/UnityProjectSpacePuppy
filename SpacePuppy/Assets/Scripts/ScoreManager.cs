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
	public bool scoreIncreasing;
	private int playerScore;
	public int highestScore = 0;

	//Nedan är array, spelobjektet playerProgress och GameData

	private GameObject playerProgress;


	private string gameDataFileName = "data.json";

	//Första metoden, hämta float datan


	public void SubmitNewPlayerScore(int newScore) {
		//	if(newScore &guiText, PlayerProgress()) {
		//		newScore = PlayerProgress(); //Kan inte göra left hand operations

		//}
	}
	//	public int GetHighestPlayerScore() {
	/*		if (scoreText > hiScoreText) < kan ej appliceras på text. Får göra om till int eller nåt
		{
			SaveGameData(); 
		}
		return PlayerProgress(); */

	//	} Måste returnera s#it

	private void LoadPlayerProgress() {
		//	playerProgress = new PlayerProgress();

		if(PlayerPrefs.HasKey("highestScore")) {
			// 					PlayerProgress() = PlayerPrefs.GetInt("highestScore"); --left hand side assigment not allowed
		}
	}
	private void SavePlayerProgress() {
		//		PlayerPrefs.SetInt("highestScore", PlayerProgress()); --invalid metod
	}

	// **************************************************************//
	/* START OCH UPDATE */

	void Start () {
		DontDestroyOnLoad (gameObject);
		LoadGameData ();
		LoadPlayerProgress ();
		playerScore = 0;

		if (PlayerPrefs.GetInt ("highscore") < myScore) {
			PlayerPrefs.SetInt ("highscore", myScore);
		}


		mittTextGameObject.text = "Highscore är: " + PlayerPrefs.GetInt ("highscore");







//		int[] minaHighscores;
//		for (int i = 0; i < 10; i++) {
//		}
//		minaHighscores [i] = PlayerPrefs.GetInt ("highscore" + i);



//		PlayerPrefs.SetString ("highscore1", "David");
//
//
//
//		if(myScore > PlayerPrefs.GetInt("highscore1")
//			PlayerPrefs.SetInt ("highscore1", myScore);
//		
//		int highestScore = PlayerPrefs.GetInt("highscore1");




	}


	void Update () {
		if (!paused) {
			if (scoreIncreasing) {
				scoreCount += pointsPerSecond * Time.deltaTime;
			}

			//Ersätt med detltatime
			scoreCount += pointsPerSecond * Time.deltaTime;

			if (scoreCount > hiScoreCount) {
				hiScoreCount = scoreCount;
			}


			scoreText.text = "Score: " + Mathf.Round (scoreCount);
			hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);
		}
	}
	// ***************************************************************\\


	private void SaveGameData() {

		string filePath = Application.dataPath + gameDataProjectFilePath;
		File.WriteAllText (filePath, dataAsJson);
	}


	private void LoadGameData()
	{
		string filePath = Application.dataPath + gameDataProjectFilePath;

		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			// 				gameData = JsonUtility.FromJson (dataAsJson); -cannot be inferred fr usage
		} 
		}

	private string gameDataProjectFilePath = "/StreamingAssets/data.json";

	private void PlayerProgress() {
		//				return highestScore; Return keyword w expression needed
	}
}