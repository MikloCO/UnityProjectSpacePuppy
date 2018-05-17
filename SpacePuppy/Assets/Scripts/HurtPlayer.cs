using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public HealthBar healthBar;
    private Movement player;
    private float damageTimer = 0;
    private bool damaged = false;
    public float respawnPosition;
    private Animator hurtAnim;

    public Transform fireParticles;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 
<<<<<<< HEAD
    private AudioSource playerAudio;
    public AudioClip astroids;
        
    public AudioClip clip;
    Movement movement;
    
=======

    private AudioSource playerAudio;
    public AudioClip astroids;
<<<<<<< HEAD
=======
=======
    public AudioSource playerAudio;
    public AudioClip clip;
<<<<<<< HEAD
    
    
=======
>>>>>>> aaa0f221e43c93630f962dfcf693378ae4fa726c
    Movement movement;
>>>>>>> 1293e102bfb8b0b4316e4dea48337ef3ea849054

    Movement movement;

<<<<<<< HEAD

=======
>>>>>>> 3babde9318d31da2c6dbf2a4b8e3b8ee974d7642
>>>>>>> b4acdc9395f7d7b1c55fa8db0d01736dab0cd367
>>>>>>> 1293e102bfb8b0b4316e4dea48337ef3ea849054
>>>>>>> d7f6cb7547c7d412ede998c5abb07e2689d99c05
    public CameraShakePuppyDamage camShake;


    private void Start () {
        player = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();
        hurtAnim = GetComponent<Animator>();
    }

    private void Update () {
        if (damaged) {
            damageTimer += Time.deltaTime;

            
        }
        if (damageTimer > 0.5f) {
            damaged = false;
            damageTimer = 0;
            hurtAnim.SetInteger("state", 0);
            fireParticles.localPosition = new Vector3(-0.51f, -0.6f);
            fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 157.245f, fireParticles.localRotation.w);
        }
        
    }


    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag("Curve") || other.CompareTag("Asteroid"))
        {
            hurtAnim.SetInteger("state", 3);
            fireParticles.localPosition = new Vector3(-2.2f, 0.8f);
            fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 90f, fireParticles.localRotation.w);

            transform.position = new Vector3(transform.position.x, respawnPosition, 0f);
           
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (!damaged) {
                damaged = true;
                player.playerHealth--;
<<<<<<< HEAD
                //healthBar.RemoveHead();
=======
 //               healthBar.RemoveHead();
>>>>>>> d7f6cb7547c7d412ede998c5abb07e2689d99c05
            }
            camShake.shakeDuration = 0.5f;
            playerAudio.pitch = Random.Range(0.5f, 1f);
            playerAudio.PlayOneShot(astroids, 0.5f);
        }


        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}