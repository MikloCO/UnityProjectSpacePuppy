using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCD : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip onTrigger;
    public HealthBar healthBar;
    private Movement player;
    private AudioSource playerAudio;
   

    void Start()
    {
        player = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CD"))
        {
            AudioClip clip;
            playerAudio.pitch = Random.Range(0.9f, 1.1f);
            playerAudio.PlayOneShot(onTrigger, 0.5f);
            do
            {
                clip = clips[Random.Range(0, clips.Length)];
            } while (clip.Equals(Camera.main.GetComponent<AudioSource>().clip));

            Camera.main.GetComponent<AudioSource>().clip = clip;
            Camera.main.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            if (player.playerHealth < 3)
            {
                player.playerHealth++;
                healthBar.AddHead();

            }
        }
    }
}

