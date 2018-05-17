using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public bool paused = false;
    public Pause pause;
	public ScoreManager scoreManager;
    public int playerHealth = 3;
    public float speed = 2.0f;
    // bool isDead = false;
    //public AudioClip deathClip;

    public Transform particleSystem;
    private float verticalDirection;
    private Rigidbody2D rb2d;
    private Animator anim;

    public enum ControllerType { HorizontalTouchRH, HorizontalTouchLH, VerticalTouchRH, VerticalTouchLH };
    public ControllerType ctrl;
    //AudioSource playerAudio;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        verticalDirection = Input.GetAxis("Vertical");
        if(verticalDirection > 0) {
            MoveUp();
        }
        else if (verticalDirection < 0){
            MoveDown();
        }

        if (ctrl == ControllerType.HorizontalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //sköld knappen på höger sida
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }

        if (ctrl == ControllerType.HorizontalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //Sköld knappen på vänster sida
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }

        if (ctrl == ControllerType.VerticalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }

        if (ctrl == ControllerType.VerticalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
        if(pause.gameSpeed < 1f) {
            rb2d.velocity = new Vector2(0,0);
            
        }
        //rb2d.velocity = Vector3.Lerp(Vector3.zero, rb2d.velocity, pause.gameSpeed);

        if (playerHealth <= 0)
        {
			scoreManager.ScoreVsHighScore();
          //  Death();
           SceneManager.LoadScene("MainMenu");
        }

    }

    private void MoveUp () {
        if(rb2d.velocity.y < 0) {
            rb2d.velocity = new Vector2(0, 0);
        }
        rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
        // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
        //particleSystem.position.y = 1;
        anim.SetInteger("state", 1);
    }

    private void MoveDown () {
        if (rb2d.velocity.y > 0) {
            rb2d.velocity = new Vector2(0, 0);
        }
        rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
        // transform.Translate(Vector3.down * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
        anim.SetInteger("state", 2);
    }

   //void Death()
   // {
   //     isDead = true;
   //     playerAudio.clip = deathClip;
   //     playerAudio.Play();

   // }

}