using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlumGen : MonoBehaviour {

	public Transform SpawnPoint;
	public GameObject Prefab;

	void OnTriggerEnter (Collider2D other) {
		Debug.Log ("Objekt gick in i trigger");

		Instantiate (Prefab, SpawnPoint.position, SpawnPoint.rotation);
	}

	void OnTriggerStay(Collider2D other) {
		Debug.Log ("Objekt inne i trigger");
	}
	void OnTriggerExit (Collider2D other) {
		Debug.Log ("Objekt lämnade trigger");
	}
}
