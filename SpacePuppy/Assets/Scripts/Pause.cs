using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public Transform swipeCountdown;

    public int difficulty = 1;

    public GameObject[] swipesDifficulty1;
    public GameObject[] swipesDifficulty2;
    public GameObject[] swipesDifficulty3;
    public GameObject[] swipesDifficulty4;
    public GameObject[] swipesDifficulty5;

    public float[] timeUntilSwipeInterval = { 10f, 15f };

    public bool swiping = false;

    public float gameSpeed = 1.0f;
    public float scoreSpeed = 1.0f;
    public float scoreSpeedIncrease = 0.1f;
    private float timer = 0f;
    private float countdownTimer = 0f;
    private bool countdown = false;
    private bool swipeActive = false;
    private float timeUntilSwipe;
    private GameObject nextSwipe;
    private GameObject currentSwipe;
    private List<GameObject> countdowns = new List<GameObject>();

    //private AudioSource myAudioSource;
   // public AudioClip voice;

    void Start () {
       // myAudioSource = GetComponent<AudioSource>();

        foreach (Transform child in swipeCountdown) {
            countdowns.Add(child.gameObject);
        }

        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipesDifficulty1[Random.Range(0, swipesDifficulty1.Length)];
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
              //  myAudioSource.pitch = Random.Range(1f,1f);
              //  myAudioSource.PlayOneShot(voice, 0.5f);
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
                currentSwipe = Instantiate(nextSwipe);
                swiping = true;
                countdown = false;
                countdownTimer = 0;
            }
            countdownTimer += Time.deltaTime * gameSpeed;
        }
    }

    public void Resume () {
        timer = 0;
        swipeActive = false;
        swiping = false;
        Destroy(currentSwipe);
        GameObject oldSwipe = nextSwipe;
        do {
            switch (difficulty) {
                case 1:
                    nextSwipe = swipesDifficulty1[Random.Range(0, swipesDifficulty1.Length)];
                    break;
                case 2:
                    nextSwipe = swipesDifficulty2[Random.Range(0, swipesDifficulty2.Length)];
                    break;
                case 3:
                    nextSwipe = swipesDifficulty3[Random.Range(0, swipesDifficulty3.Length)];
                    break;
                case 4:
                    nextSwipe = swipesDifficulty4[Random.Range(0, swipesDifficulty4.Length)];
                    break;
                case 5:
                    nextSwipe = swipesDifficulty5[Random.Range(0, swipesDifficulty5.Length)];
                    break;
            }
        } while (nextSwipe.Equals(oldSwipe));
        Invoke("ContinueGame", 1f);
    }

    public void IncreaseDifficulty () {
        difficulty += 1;
        scoreSpeed += scoreSpeedIncrease;
    }
    
    private void ContinueGame () {
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        gameSpeed = 1f;
    }
}