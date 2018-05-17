﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour {
    
    public List<Vector3> coinPositions = new List<Vector3>();

    public int numberOfCoins;
    public int coinsCollected;

    private ScoreManager scoreManager;
    public CountCoins coins;
    public Pause pause;

    private int score;

    private void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        numberOfCoins = coins.Coins();
    }

    public void Finish (bool perfect) {
        scoreManager.SwipeScore(coinsCollected, perfect);
        coinsCollected = 0;
        coinPositions.Clear();
        scoreManager.speedPointMultiplier += scoreManager.speedPointMultiplierIncrease;
        pause.scoreSpeed += 0.1f;
    }

    public void AddCoin (Vector3 position) {
        coinPositions.Add(position);
        coinsCollected++;
    }

    public bool AllCoins () {
        return numberOfCoins == coinsCollected;
    }
}
