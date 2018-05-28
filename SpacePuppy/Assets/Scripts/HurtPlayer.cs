using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public HealthBar healthBar;
    private Movement player;
    private float damageTimer = 0;
    private bool damaged = false;
    public float respawnPosition;
    private Animator anim;

    public Transform fireParticles;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float hurtAnimTime = 0.5f;
    public float invulnTime = 2f;
    private AudioSource playerAudio;
    public AudioClip astroid, astroidBelt;
    public CameraShakePuppyDamage camShake;


    private void Start () {
        player = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update () {
        if (damaged) {
            damageTimer += Time.deltaTime;
        }
        if(damageTimer > hurtAnimTime) {
            anim.SetBool("hurt", false);
            fireParticles.gameObject.SetActive(true);
        }
        if (damageTimer > invulnTime) {
            damaged = false;
            damageTimer = 0;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            //fireParticles.localPosition = new Vector3(-0.51f, -0.6f);
            //fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 157.245f, fireParticles.localRotation.w);
        }
        
    }


    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag("Asteroid") || other.CompareTag("Curve"))
        {
            //fireParticles.localPosition = new Vector3(-2.2f, 0.8f);
            //fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 90f, fireParticles.localRotation.w);

            transform.position = new Vector3(transform.position.x, respawnPosition, 0f);
           
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (!damaged) {
                anim.SetBool("hurt", true);
                fireParticles.gameObject.SetActive(false);
                damaged = true;
                player.playerHealth--;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
                healthBar.RemoveHead();

            }
        }

        if (other.CompareTag("Asteroid")) {
            camShake.shakeDuration = 0.3f;
            playerAudio.pitch = Random.Range(0.4f, 0.6f);
            playerAudio.PlayOneShot(astroid, 0.4f);
        }

        if (other.CompareTag("Curve"))
        {
            camShake.shakeDuration = 0.7f;
            playerAudio.pitch = Random.Range(0.5f, 0.6f);
            playerAudio.PlayOneShot(astroidBelt, 0.4f);
        }


        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}