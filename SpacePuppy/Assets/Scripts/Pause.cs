using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public RotatingScript rot;
    public CurvesGenSwitch curv1;
    public BackgroundGenSwitch bg;
    public Movement mov;
    public ScreenDeath scr;
    public ScoreManager scoreM;
    public ObjectGenManager ogm; //ta bort

    public GameObject[] swipes;

    public float[] timeUntilSwipeInterval = { 10f, 15f };

    private bool paused = false;
    private float timer = 0f;
    private float timeUntilSwipe;
    private GameObject nextSwipe;

    void Start () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        paused = false;
        timer = 0f;
    }

    void Update () {
        if (!paused) {
            if (timer > timeUntilSwipe) {
                timer = 0;
                PauseGame();
            }
            timer += Time.deltaTime;
        }
    }

    private void PauseGame () {
        rot.paused = true;
        curv1.Pause();
        bg.paused = true;
        mov.paused = true;
        scr.paused = true;
        scoreM.paused = true;
        ogm.Pause();
        nextSwipe.SetActive(true);
        paused = true;
    }

    public void Resume () {
        nextSwipe.SetActive(false);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        Invoke("ContinueGame", 1);
    }

    private void ContinueGame () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        rot.paused = false;
        curv1.Resume();
        bg.paused = false;
        mov.paused = false;
        scr.paused = false;
        scoreM.paused = false;
        ogm.Resume();
        paused = false;
    }
}
