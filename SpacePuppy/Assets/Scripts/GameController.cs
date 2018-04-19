using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public int score = 0;
    public List<Vector3> coinPositions = new List<Vector3>();

	void Update () {
		
	}

    public void FinishLevel () {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = 0;
        while(nextScene == currentScene)
            nextScene = Random.Range(0, 5);
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }

    public void AddCoin (Vector3 position) {
        coinPositions.Add(position);
    }
}
