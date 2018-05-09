using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public bool paused = false;
    public Pause pause;
    public int playerHealth = 3;
    public float speed = 2.0f;

    private float verticalDirection;
    private Rigidbody2D rb2d;

    public enum ControllerType { HorizontalTouch, VerticalTouch, Control3 };
    public ControllerType ctrl;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalDirection = Input.GetAxis("Vertical");
        rb2d.AddForce(Vector3.up * speed * verticalDirection);

        if (ctrl == ControllerType.HorizontalTouch && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                //transform.Translate(Vector3.up * speed * Time.deltaTime, Camera.main.transform);
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
                // transform.Translate(Vector3.down * speed * Time.deltaTime, Camera.main.transform);
            }
        }

        if (ctrl == ControllerType.VerticalTouch && Input.GetMouseButton(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
            }
        }

        rb2d.velocity = Vector3.Lerp(Vector3.zero, rb2d.velocity, pause.gameSpeed);

        if (playerHealth <= 0) {
            SceneManager.LoadScene("MainMenu");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "KillZone")
        {
            //	Application.LoadLevel("PointSystem"); Behöver vi den här?
        }
    }
    //void OnCollisionEnter2D (Collision2D other)
    //{
    //       if (other.gameObject.tag == "Player") {
    //           ScreenDeath();
    //       }
    //}
}
