using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private Pause pause;

    private void Start () {
        pause = FindObjectOfType<Pause>();
    }

    public void PressedMainMenu()
    {
        Invoke("ReturnMenu", 0.4f);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void PressedPlayAgain()
    {
        Invoke("RunAgain", 0.4f);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Pause()
    {
        pause.gameSpeed = 0f;
    }

    public void RunAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
}
