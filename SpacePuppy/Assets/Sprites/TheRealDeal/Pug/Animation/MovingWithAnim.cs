using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWithAnim : MonoBehaviour
{
    //public bool paused = false;
    public Pause pause;
    public ScoreManager scoreManager;
    public int playerHealth = 3;
    public float speed = 2.0f;
    //bool isDead = false;
    //public AudioClip deathClip;

    private float verticalDirection;
    private Rigidbody2D rb2d;
    private Animator anim;

    public enum ControllerType { HorizontalTouchRH, HorizontalTouchLH, VerticalTouchRH, VerticalTouchLH };
    public ControllerType ctrl;
    // AudioSource playerAudio;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(playerHealth);
        verticalDirection = Input.GetAxis("Vertical");
        rb2d.AddForce(Vector3.up * speed * verticalDirection);
        // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime * verticalDirection, Camera.main.transform);

        if (ctrl == ControllerType.HorizontalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //sköld knappen på höger sida
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
                // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
                anim.SetInteger("state", 1);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
                // transform.Translate(Vector3.down * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
                anim.SetInteger("state", 2);
            }
        }

        if (ctrl == ControllerType.HorizontalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //Sköld knappen på vänster sida
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
                anim.SetInteger("state", 1);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
                anim.SetInteger("state", 2);
            }
        }

        if (ctrl == ControllerType.VerticalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
                anim.SetInteger("state", 1);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
                anim.SetInteger("state", 2);
            }
        }

        if (ctrl == ControllerType.VerticalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
                anim.SetInteger("state", 1);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
                anim.SetInteger("state", 2);
            }
        }
        if (pause.gameSpeed < 1f)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        //rb2d.velocity = Vector3.Lerp(Vector3.zero, rb2d.velocity, pause.gameSpeed);

        if (playerHealth <= 0)
        {
            scoreManager.scoreVsHighScore();
            //Death();
            SceneManager.LoadScene("MainMenu");
        }

    }

    //void Death()
    // {
    //     isDead = true;
    //     playerAudio.clip = deathClip;
    //     playerAudio.Play();

    // }

}