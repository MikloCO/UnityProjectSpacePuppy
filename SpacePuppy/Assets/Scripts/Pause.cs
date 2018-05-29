using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public Transform swipeCountdown;
    public Transform swipeResult;

    private Movement movement;

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
    private float afterSwipeTimer = 0f;
    private int count = 3;
    private bool countdown = false;
    private bool swipeActive = false;
    private bool afterSwipe = false;
    private float timeUntilSwipe;
    private GameObject nextSwipe;
    private GameObject currentSwipe;
    private List<GameObject> countdowns = new List<GameObject>();
    private List<GameObject> results = new List<GameObject>();

    private AudioSource myAudioSource;
    public AudioClip three;
    public AudioClip two;
    public AudioClip one;
    public AudioClip swipe;
    public AudioClip badS;
    public AudioClip goodS;
    public AudioClip perfectS;
    public AudioClip stressfull;

    void Start () {
        myAudioSource = GetComponent<AudioSource>();

        foreach (Transform child in swipeCountdown) {
            countdowns.Add(child.gameObject);
        }

        foreach (Transform child in swipeResult) {
            results.Add(child.gameObject);
        }

        movement = FindObjectOfType<Movement>();
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        nextSwipe = swipesDifficulty1[Random.Range(0, swipesDifficulty1.Length)];
        gameSpeed = 1f;
        timer = 0f;
        count = 3;
    }

    void Update () {
        if (!swipeActive) {
            if (timer > timeUntilSwipe && count == 3) {
                myAudioSource.PlayOneShot(three, 0.5f);
                countdown = true;
                countdowns[0].SetActive(true);
                swipeActive = true;
                count = 2;
            }
            timer += Time.deltaTime * gameSpeed;
        }
        if (countdown) {
            if (countdownTimer >= 1f && count == 2) {
                myAudioSource.PlayOneShot(two, 0.5f);
                countdowns[0].SetActive(false);
                countdowns[1].SetActive(true);
                count = 1;
            }
            if (countdownTimer >= 2f && count == 1) {
                myAudioSource.PlayOneShot(one, 0.5f);
                countdowns[1].SetActive(false);
                countdowns[2].SetActive(true);
                count = 0;
            }
            if(countdownTimer >= 3f && count == 0) {
                myAudioSource.PlayOneShot(swipe, 0.5f);
                countdowns[2].SetActive(false);
                countdowns[3].SetActive(true);
                count = -1;
            }
            if(countdownTimer >= 4f && count == -1) {
                myAudioSource.PlayOneShot(stressfull, 0.5f);
                countdowns[3].SetActive(false);
                gameSpeed = 0.2f;
                movement.SwipeSlow();
                currentSwipe = Instantiate(nextSwipe);
                swiping = true;
                countdown = false;
                countdownTimer = 0;
                count = 3;
            }
            countdownTimer += Time.deltaTime * gameSpeed;
        }
        if (afterSwipe) {
            afterSwipeTimer += Time.deltaTime;
            if(afterSwipeTimer > 1f) {
                afterSwipe = false;
                afterSwipeTimer = 0f;
                ContinueGame();
            }
        }
    }

    public void Resume (bool perfect, bool failed) {
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
        afterSwipe = true;
        if (perfect) {
            results[0].SetActive(true);
            myAudioSource.PlayOneShot(perfectS, 0.5f);
        }
        else if (failed) {
            results[2].SetActive(true);
            myAudioSource.PlayOneShot(badS, 0.5f);
        }
        else {
            results[1].SetActive(true);
            myAudioSource.PlayOneShot(goodS, 0.5f);
        }
    }

    public void IncreaseDifficulty () {
        difficulty += 1;
        scoreSpeed += scoreSpeedIncrease;
    }
    
    private void ContinueGame () {
        foreach(GameObject g in results) {
            g.SetActive(false);
        }
        timeUntilSwipe = Random.Range(timeUntilSwipeInterval[0], timeUntilSwipeInterval[1]);
        gameSpeed = 1f;
    }
}