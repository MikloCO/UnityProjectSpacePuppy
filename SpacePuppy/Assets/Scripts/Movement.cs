using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool paused = false;

    public float speed = 5.0f;

    private float verticalDirection;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        if (!paused) {

            //verticalDirection = Input.GetAxis("Vertical");
            //transform.Translate(new Vector3(0, verticalDirection, 0) * speed * Time.deltaTime, Camera.main.transform);


            if (Input.GetMouseButton(0)) {
                if (Input.mousePosition.x < Screen.width / 2) {
                    //transform.Translate(Vector3.up * speed * Time.deltaTime, Camera.main.transform);
                    rb2d.AddForce(Vector3.up * speed);

                }
                else if (Input.mousePosition.x > Screen.width / 2) {
                    rb2d.AddForce(Vector3.down * speed);

                    // transform.Translate(Vector3.down * speed * Time.deltaTime, Camera.main.transform);

                }
            }
        }
        else if (paused) {
            rb2d.velocity = new Vector2(0,0);
        }
	}


private void OnTriggerEnter2D(Collider2D collision) {
	if(collision.name == "KillZone") {
		Application.LoadLevel("PointSystem");
	}
}
	void OnCollisionEnter2D (Collision2D other)
	{
	//	if(other.gameObject.tag
	}
}