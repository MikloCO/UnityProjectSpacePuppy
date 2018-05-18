using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
 
    public void PlayGame()
    {
        Invoke("PlayGameButton", 0.4f);
    }

    void PlayGameButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
   
}
