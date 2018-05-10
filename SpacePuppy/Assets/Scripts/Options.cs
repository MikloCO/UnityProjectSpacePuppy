﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

   public void ReturnMenu()
    {
       SceneManager.LoadScene("MainMenu");
   }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
