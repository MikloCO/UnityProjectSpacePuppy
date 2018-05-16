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
   
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //oklart om detta behövs

    AudioSource playerAudio;
    Movement movement;

    public CameraShakePuppyDamage camShake;


    private void Start()
    {
        player = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        if (damaged) {
            damageTimer += Time.deltaTime;
            
       //     damageImage.color = flashColour;
        }
        if (damageTimer > 0.5f) {
            damaged = false;
            damageTimer = 0;
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
        if (!damaged) {
            if (other.CompareTag("Curve") || other.CompareTag("Asteroid")) {
                //Debug.Log(respawnPosition);
                transform.position = new Vector3(transform.position.x, respawnPosition, 0f);
                //healthBar.Damage();
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                damaged = true;
                player.playerHealth--;


                //camShake.Invoke("update", 1f);



                // healthbar.value = player.playerHealth; //<-- detta kommer sedan för att ändra healthbar (hundhuvuden)//Märta
                //Debug.Log(player.playerHealth);'
                // playerAudio.Play();
            }
            
        }
        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}