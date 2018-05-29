using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private Pause pause;
    public Text scoreText;
    public GameObject loadScene;
   

    private void Start () {
       pause = FindObjectOfType<Pause>();
       scoreText.text = "" + Mathf.Round(ScoreManager.scoreCount);        
    }

    public void PressedMainMenu()
    {
        Invoke("ReturnMenu", 0.4f);
    }

    public void ReturnMenu()
    {
        loadScene.SetActive(true);
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
        loadScene.SetActive(true);
        SceneManager.LoadScene("Level 1");
    }
}
