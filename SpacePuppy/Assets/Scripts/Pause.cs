using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

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
        gameSpeed = 1f;
    }
}
