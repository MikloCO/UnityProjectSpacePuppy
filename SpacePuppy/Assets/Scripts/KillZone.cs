using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {
    public Movement player;
    
    private void Update () {
        Debug.Log(player.playerHealth);
    }
    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Hurt");
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x, 0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.playerHealth --;
            //Execute this code if the colliding object is the player, to access the player gameObject, use coll.
        }
    }
}