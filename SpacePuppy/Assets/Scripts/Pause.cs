using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public Transform swipeCountdown;
    public Transform swipe;

    private List<GameObject> swipes = new List<GameObject>();

    public float[] timeUntilSwipeInterval = { 10f, 15f };

    public float gameSpeed = 1.0f;
    public float scoreSpeed = 1.0f;
    private float timer = 0f;
    private float countdownTimer = 0f;
    private bool countdown = false;
    private bool swipeActive = false;
    private float timeUntilSwipe;
    private GameObject nextSwipe;
    private List<GameObject> countdowns = new List<GameObject>();

    void Start () {
        foreach (Transform child in swipeCountdown) {
            countdowns.Add(child.gameObject);
        }
        foreach (Transform child in swipe) {
            swipes.Add(child.gameObject);
        }

        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipes[Random.Range(0, swipes.Count)];
        gameSpeed = 1f;
        timer = 0f;
    }

    void Update () {
        if (!swipeActive) {
            if (timer > timeUntilSwipe) {
                countdown = true;
                countdowns[0].SetActive(true);
                swipeActive = true;
            }
            timer += Time.deltaTime * gameSpeed;
        }
        if (countdown) {
            if (countdownTimer >= 1f) {
                countdowns[0].SetActive(false);
                countdowns[1].SetActive(true);
            }
            if (countdownTimer >= 2f) {
                countdowns[1].SetActive(false);
                countdowns[2].SetActive(true);
            }
            if(countdownTimer >= 3f) {
                countdowns[2].SetActive(false);
                countdowns[3].SetActive(true);
            }
            if(countdownTimer >= 4f) {
                countdowns[3].SetActive(false);
                gameSpeed = 0.2f;
                nextSwipe.SetActive(true);
                countdown = false;
                countdownTimer = 0;
            }
            countdownTimer += Time.deltaTime * gameSpeed;
        }
    }

    private void Activate3 () {
        countdowns[0].SetActive(true);
        Invoke("Activate2", 1f);
    }

    private void Activate2 () {
        countdowns[0].SetActive(false);
        countdowns[1].SetActive(true);
        Invoke("Activate1", 1f);
    }

    private void Activate1 () {
        countdowns[1].SetActive(false);
        countdowns[2].SetActive(true);
        Invoke("ActivateSwipe", 1f);
    }

    private void ActivateSwipe () {
        countdowns[2].SetActive(false);
        countdowns[3].SetActive(true);
        gameSpeed = 0.2f;
        Invoke("PauseGame", 1f);
    }

    private void PauseGame () {
        countdowns[3].SetActive(false);
        nextSwipe.SetActive(true);
    }

    public void Resume () {
        timer = 0;
        swipeActive = false;
        nextSwipe.SetActive(false);
        GameObject oldSwipe = nextSwipe;
        do {
            nextSwipe = swipes[Random.Range(0, swipes.Count)];
        } while (nextSwipe.Equals(oldSwipe));
        Invoke("ContinueGame", 1f);
    }

    private void ContinueGame () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        gameSpeed = 1f;
    }
}