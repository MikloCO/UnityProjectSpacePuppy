﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Movement player;
  //  public GameObject[] heads;
    public GameObject head1, head2, head3, gameOver;
    public Movement mov; // public kanske
    
    void Start () {
        head1.gameObject.SetActive(true);
        head2.gameObject.SetActive(true);
        head3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }
	public void update()
    {
        if (mov.playerHealth > 3)
            mov.playerHealth = 3;

        switch (mov.playerHealth)
        {
            case 3:
                head1.gameObject.SetActive(true);
                head2.gameObject.SetActive(true);
                head3.gameObject.SetActive(true);
                break;
            case 2:
                head1.gameObject.SetActive(true);
                head2.gameObject.SetActive(true);
                head3.gameObject.SetActive(false);
                break;
            case 1:
                head1.gameObject.SetActive(true);
                head2.gameObject.SetActive(false);
                head3.gameObject.SetActive(false);
                break;
            case 0:
                head1.gameObject.SetActive(false);
                head2.gameObject.SetActive(false);
                head3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;          
        }
        
        //heads[3].SetActive(false);
    }

}
