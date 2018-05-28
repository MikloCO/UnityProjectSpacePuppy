using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour {
    
    public List<Vector3> coinPositions = new List<Vector3>();

    public int numberOfCoins;
    public int coinsCollected;

    private ScoreManager scoreManager;
    public CountCoins coins;
    private Pause pause;

    private int score;

    private void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        pause = FindObjectOfType<Pause>();
        numberOfCoins = coins.Coins();
    }

    public bool Finish (bool perfect, bool failed) {
        scoreManager.SwipeScore(coinsCollected, perfect);
        if((float)coinsCollected/(float)numberOfCoins <= 0.5f) {
            failed = true;
        }
        coinsCollected = 0;
        coinPositions.Clear();
        if (pause.difficulty < 5 && !failed) {
            pause.IncreaseDifficulty();
            scoreManager.difficultyMultiplier += scoreManager.difficultyMultiplierIncrease;
        }
        return failed;
    }

    public void AddCoin (Vector3 position) {
        coinPositions.Add(position);
        coinsCollected++;
    }

    public bool AllCoins () {
        return numberOfCoins == coinsCollected;
    }
}
