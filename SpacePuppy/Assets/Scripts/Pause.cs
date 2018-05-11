using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public Transform swipeCountdown;
    public GameObject[] swipes;
    public GameObject pauseMenu;

    public float[] timeUntilSwipeInterval = { 10f, 15f };

    public float gameSpeed = 0.0f;
    private float timer = 0f;
    private bool swipeActive = false;
    private float timeUntilSwipe;
    private GameObject nextSwipe;
    private List<GameObject> countdowns = new List<GameObject>();

    void Start () {
        foreach (Transform child in swipeCountdown) {
            countdowns.Add(child.gameObject);
        }
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        gameSpeed = 1f;
        timer = 0f;
    }

    void Update () {
        if (!swipeActive) {
            if (timer > timeUntilSwipe) {
                Activate3();
                swipeActive = true;
            }
            timer += Time.deltaTime * gameSpeed;
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

    public void ActualPause () {
        gameSpeed = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume () {
        timer = 0;
        swipeActive = false;
        nextSwipe.SetActive(false);
        nextSwipe = swipes[Random.Range(0, swipes.Length)];
        Invoke("ContinueGame", 1f);
    }

    private void ContinueGame () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        gameSpeed = 1f;
    }
}