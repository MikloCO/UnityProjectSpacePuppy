using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
<<<<<<< HEAD
=======
    public RotatingScript rot;
    public CurvesGenSwitch curv1;
    public BackgroundGenSwitch bg;
    public Movement mov;
    public ScreenDeath scr;
    public ScoreManager scoreM;
    public ObjectGenManager ogm; //ta bort
>>>>>>> 6590b89a7c7500336969f76b77c80992fa8e519c

    public GameObject[] swipes;

    public float[] timeUntilSwipeInterval = { 10f, 15f };

    public float gameSpeed = 0.0f;
    private float timer = 0f;
    private float timeUntilSwipe;
    private GameObject nextSwipe;

    void Start () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        gameSpeed = 1f;
        timer = 0f;
    }

    void Update () {
        if (timer > timeUntilSwipe) {
            timer = 0;
            PauseGame();
        }
        timer += Time.deltaTime * gameSpeed;
    }

    private void PauseGame () {
<<<<<<< HEAD
=======
        rot.paused = true;
        curv1.Pause();
        bg.paused = true;
        mov.paused = true;
        scr.paused = true;
        scoreM.paused = true;
        ogm.Pause();
>>>>>>> 6590b89a7c7500336969f76b77c80992fa8e519c
        nextSwipe.SetActive(true);
        gameSpeed = 0f;
    }

    public void Resume () {
        nextSwipe.SetActive(false);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        Invoke("ContinueGame", 1);
    }

    private void ContinueGame () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
<<<<<<< HEAD
        gameSpeed = 1f;
=======
        rot.paused = false;
        curv1.Resume();
        bg.paused = false;
        mov.paused = false;
        scr.paused = false;
        scoreM.paused = false;
        ogm.Resume();
        paused = false;
>>>>>>> 6590b89a7c7500336969f76b77c80992fa8e519c
    }
}
