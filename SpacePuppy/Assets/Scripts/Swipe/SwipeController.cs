using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour {

    public int pointsPerCollected = 10;

    public List<Vector3> coinPositions = new List<Vector3>();

    public int numberOfCoins;
    public int coinsCollected;

    private ScoreManager scoreManager;
    public CountCoins coins;

    private int score;

    private void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        numberOfCoins = coins.Coins();
    }

    public void Finish (bool perfect) {
        scoreManager.SwipeScore(coinsCollected, perfect);
    }

    public void AddCoin (Vector3 position) {
        coinPositions.Add(position);
        coinsCollected++;
    }

    public bool AllCoins () {
        return numberOfCoins == coinsCollected;
    }
}
