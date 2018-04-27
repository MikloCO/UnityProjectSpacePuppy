using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject swipe;

    private bool paused = false;

    void Start () {
        paused = false;
    }

    void Update () {
        Debug.Log(paused);
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused) {
                PauseGame();
            }
            else if (paused) {
                ContinueGame();
            }
        }
    }

    private void PauseGame () {
        Debug.Log("Paused");
        Time.timeScale = 0;
        paused = true;
    }

    private void ContinueGame () {
        Debug.Log("Unpaused");
        Time.timeScale = 1;
        paused = false;
    }
}
