using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
        //Debug.Log("respawn");
        transform.parent.GetComponent<HurtPlayer>().respawnPosition = col.gameObject.transform.position.y;
	}
}
