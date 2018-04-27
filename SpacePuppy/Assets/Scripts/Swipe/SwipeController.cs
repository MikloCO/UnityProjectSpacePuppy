using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeController : MonoBehaviour {
    public int score = 0;
    public List<Vector3> coinPositions = new List<Vector3>();
    public int numberOfCoins;
    public int coinsCollected;

    public CountCoins coins;

    private void Start () {
        numberOfCoins = coins.Coins();
    }
    void Update () {
		
	}

    public void NextLevel () {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = 0;
        while(nextScene == currentScene)
            nextScene = Random.Range(0, 3);
        Debug.Log(nextScene);
        //SceneManager.LoadScene(nextScene);
    }

    public void AddCoin (Vector3 position) {
        coinPositions.Add(position);
        coinsCollected++;
    }

    public bool AllCoins () {
        return numberOfCoins == coinsCollected;
    }
}
