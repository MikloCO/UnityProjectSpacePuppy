using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone: MonoBehaviour {
	void OnCollisionEnter2D(Collision2D KillZone) {
		if (KillZone.gameObject.tag == "Player"){
			Debug.Log ("Dead");
			//Execute this code if the colliding object is the player, to access the player gameObject, use coll.
		}
	}
}