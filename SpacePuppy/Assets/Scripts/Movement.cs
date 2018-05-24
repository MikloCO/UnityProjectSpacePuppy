using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
    //public bool paused = false;
    private Pause pause;
    public ScoreManager scoreManager;
    public int playerHealth = 3;
    public float speed = 2.0f;
    bool isDead = false;
    

    public Transform fireParticles;
    private float verticalDirection;
    private Rigidbody2D rb2d;
    private Animator anim;

    public enum ControllerType { HorizontalTouchRH, HorizontalTouchLH, VerticalTouch, MoveTowardTouch };
    public static ControllerType ctrl = ControllerType.VerticalTouch;

    public void SetControllerType(int control) {
        switch (control) {
            case 0:
                ctrl = ControllerType.VerticalTouch;
                break;
            case 1:
                ctrl = ControllerType.MoveTowardTouch;
                break;
            case 2:
                ctrl = ControllerType.HorizontalTouchRH;
                break;
            case 3:
                ctrl = ControllerType.HorizontalTouchLH;
                break;

        }
    }


    void Start () {
        pause = FindObjectOfType<Pause>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		isDead = false;
    }

    void Update () {
        verticalDirection = Input.GetAxis("Vertical");
        if (verticalDirection > 0) {
            MoveUp();
        }
        else if (verticalDirection < 0) {
            MoveDown();
        }

        if(ctrl == ControllerType.MoveTowardTouch && !pause.swiping && Input.GetMouseButton(0))
        {
            if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y) {
                MoveUp();
            }
            else if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y){
                MoveDown();
            }
        }

        if (ctrl == ControllerType.HorizontalTouchRH && !pause.swiping && Input.GetMouseButton(0)) //sköld knappen på höger sida
        {
            if (Input.mousePosition.x > Screen.width / 2) {
                MoveUp();
            }
            else {
                MoveDown();
            }
        }

        if (ctrl == ControllerType.HorizontalTouchLH && !pause.swiping && Input.GetMouseButton(0)) //Sköld knappen på vänster sida
        {
            if (Input.mousePosition.x < Screen.width / 2) {
                MoveUp();
            }
            else {
                MoveDown();
            }
        }

        if (ctrl == ControllerType.VerticalTouch && !pause.swiping && Input.GetMouseButton(0)) {
            if (Input.mousePosition.y > Screen.height / 2) {
                MoveUp();
            }
            else {
                MoveDown();
            }
        }
        
        if (pause.gameSpeed < 1f) {
            rb2d.velocity = new Vector2(0, 0);

        }
        //rb2d.velocity = Vector3.Lerp(Vector3.zero, rb2d.velocity, pause.gameSpeed);

        if (playerHealth <= 0 && !isDead) {
            scoreManager.ScoreVsHighScore();
            //  Death();
            SceneManager.LoadScene("DeathMenu");
			isDead = true;
        }

    }

    private void MoveUp () {
        if (rb2d.velocity.y < 0) {
            rb2d.velocity = new Vector2(0, 0);
        }
        rb2d.AddForce(Vector3.up * speed);
        // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
        anim.SetInteger("state", 1);
        fireParticles.localPosition = new Vector3(-1.79f, 0.15f);
        fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 117.892f,fireParticles.localRotation.w);
    }

    private void MoveDown () {
        if (rb2d.velocity.y > 0) {
            rb2d.velocity = new Vector2(0, 0);
        }
        rb2d.AddForce(Vector3.down * speed);
        // transform.Translate(Vector3.down * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform)
        anim.SetInteger("state", 2);
        fireParticles.localPosition = new Vector3(-1.62f, 1.47f);
        fireParticles.localRotation.Set(fireParticles.localRotation.x, fireParticles.localRotation.y, 47.48f, fireParticles.localRotation.w);
    }
}