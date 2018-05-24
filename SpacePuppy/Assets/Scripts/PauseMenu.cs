﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Pause pause;
    
    public void ReturnMenu () {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Pause () {
        pause.gameSpeed = 0f;
    }

    public void Resume () {
        if (pause.swiping) {
            pause.gameSpeed = 0.2f;
        }
        else {
            pause.gameSpeed = 1f;
        }
    }
}
