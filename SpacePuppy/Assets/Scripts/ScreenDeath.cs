using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDeath : MonoBehaviour {

    private Rigidbody2D rb2d;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update () {

        if (transform.position.y > 3.6) {
            //rb2d.velocity = Vector3.zero;

            transform.position = new Vector3(transform.position.x, 3.6f, transform.position.z);
        }
        else if (transform.position.y < -5) {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }

    }
}