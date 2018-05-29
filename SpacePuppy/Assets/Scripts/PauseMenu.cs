using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Pause pause;
    public Button button;
    public GameObject loadScreen;

    public void ReturnMenu () {
        loadScreen.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Pause () {
        pause.gameSpeed = 0f;
        button.enabled = false;
    }

    public void Resume () {
        button.enabled = true;
        if (pause.swiping) {
            pause.gameSpeed = 0.2f;
        }
        else {
            pause.gameSpeed = 1f;
        }
    }
}
