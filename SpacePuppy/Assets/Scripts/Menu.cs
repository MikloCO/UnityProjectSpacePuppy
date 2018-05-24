using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    //public CanvasTransferToScene canvasChange;

    public void PlayGame()
    {
        Invoke("PlayGameButton", 0.4f);
    }

    void PlayGameButton()
    {
        //canvasChange.MoveToNextScene();
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
   
}
