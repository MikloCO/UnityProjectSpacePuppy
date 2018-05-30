using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//8:50 fr https://www.youtube.com/watch?v=FaX4B_FMPIg

public class PickUpPoints : MonoBehaviour
{

    private ScoreManager scoreManager;
    private AudioSource myAudioSource;
    private Pause pause;
    public AudioClip crackers;
    public AudioClip bark;
    public float pickUpTime = 1f;

    private bool timerStart = false;
    private int collected = 0;
    private float timer = 0f;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        pause = FindObjectOfType<Pause>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime * pause.gameSpeed;
            if (timer <= pickUpTime && collected >= 5)
            {
                scoreManager.BonusBoneScore();
                myAudioSource.pitch = Random.Range(0.5f, 1.5f);
                myAudioSource.PlayOneShot(bark, 0.5f);
                collected = 0;
                timer = 0f;
                timerStart = false;
            }
            if (timer >= pickUpTime)
            {
                collected = 0;
                timer = 0f;
                timerStart = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DogCracker"))
        {   //takes current points and adds the dogbones bonus points.
            if (!timerStart)
            {
                timerStart = true;

            }
            collected++;
            scoreManager.BoneScore();
            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
            myAudioSource.PlayOneShot(crackers, 0.5f);

            other.transform.Find("CrackerParticleSystem").GetComponent<ParticleSystem>().Play();
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(RemoveCracker(other.gameObject));
        }
    }

    IEnumerator RemoveCracker(GameObject obj)
    {
        yield return new WaitForSeconds(4f);
        Destroy(obj);
    }

}
