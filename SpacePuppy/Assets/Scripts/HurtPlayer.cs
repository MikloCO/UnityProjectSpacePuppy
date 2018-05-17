using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    //https://www.youtube.com/watch?time_continue=193&v=a916_lhps04

    public HealthBar healthBar;
    private Movement player;
    private float damageTimer = 0;
    private bool damaged = false;
    public float respawnPosition;
    //public image damageImage;
    private Animator hurtAnim;

    public Transform fireParticles;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //oklart om detta behövs
    public AudioSource playerAudio;
    public AudioClip clip;
    Movement movement;

<<<<<<< HEAD

=======
>>>>>>> ef38c5ca558ad2456f8b10b28865aa5776b33904
    public CameraShakePuppyDamage camShake;


    private void Start () {
        player = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();
        hurtAnim = GetComponent<Animator>();
    }

    private void Update () {
        if (damaged) {
            damageTimer += Time.deltaTime;
            hurtAnim.SetInteger("state", 3);
            fireParticles.localPosition = new Vector3(-2.2f, 0.8f);
            fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 90f, fireParticles.localRotation.w);

            //     damageImage.color = flashColour;
        }
        if (damageTimer > 0.5f) {
            damaged = false;
            damageTimer = 0;
            hurtAnim.SetInteger("state", 0);
            fireParticles.localPosition = new Vector3(-0.51f, -0.6f);
            fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 157.245f, fireParticles.localRotation.w);
        }
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
        //}
    }

    //public void TakeDamage(int amount)
    //{

    //}

    void OnTriggerEnter2D (Collider2D other) {

        if (other.CompareTag("Curve") || other.CompareTag("Asteroid"))
        {
            other.GetComponent<AudioSource>().Play();
            //Debug.Log(respawnPosition);
            transform.position = new Vector3(transform.position.x, respawnPosition, 0f);
            //healthBar.Damage();

            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (!damaged) {
                damaged = true;
                player.playerHealth--;
            }

            camShake.shakeDuration = 0.5f;



            // healthbar.value = player.playerHealth; //<-- detta kommer sedan för att ändra healthbar (hundhuvuden)//Märta
            //Debug.Log(player.playerHealth);'
            playerAudio.Play();
        }


        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}