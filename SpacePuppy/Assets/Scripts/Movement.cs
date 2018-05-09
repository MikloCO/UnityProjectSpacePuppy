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

    public enum ControllerType { HorizontalTouchRH, HorizontalTouchLH, VerticalTouchRH, VerticalTouchLH };
    public ControllerType ctrl;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalDirection = Input.GetAxis("Vertical");
        rb2d.AddForce(Vector3.up * speed * verticalDirection);
       // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime * verticalDirection, Camera.main.transform);

        if (ctrl == ControllerType.HorizontalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //sköld knappen på höger sida
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
               // transform.Translate(Vector3.up * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
               // transform.Translate(Vector3.down * speed * pause.gameSpeed * Time.deltaTime, Camera.main.transform);
            }
        }

        if (ctrl == ControllerType.HorizontalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0)) //Sköld knappen på vänster sida
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                rb2d.AddForce(Vector3.up * speed * pause.gameSpeed);
            }
            else
            {
                rb2d.AddForce(Vector3.down * speed * pause.gameSpeed);
            }
        }

        if (ctrl == ControllerType.VerticalTouchRH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
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

        if (ctrl == ControllerType.VerticalTouchLH && pause.gameSpeed > 0.3 && Input.GetMouseButton(0))
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

        //rb2d.velocity = Vector3.Lerp(Vector3.zero, rb2d.velocity, pause.gameSpeed);

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}