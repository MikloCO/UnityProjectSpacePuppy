using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private Movement player;

    private float damageTimer = 0;
    private bool damaged = false;

    private void Start () {
        player = GetComponent<Movement>();
    }

    private void Update () {
        if (damaged) {
            damageTimer += Time.deltaTime;
        }
        if(damageTimer > 0.5f) {
            damaged = false;
            damageTimer = 0;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (!damaged) {
            if (other.CompareTag("Curve") || other.CompareTag("Asteroid")) {
                transform.position = new Vector3(transform.position.x, 0f, 0f);
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                damaged = true;
                player.playerHealth--;
                Debug.Log(player.playerHealth);
            }
            
        }
        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}