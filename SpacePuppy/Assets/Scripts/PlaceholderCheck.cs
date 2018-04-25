using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderCheck : MonoBehaviour {
	public Camera camera;
	// Use this for initialization
	void Start () {
		GameObject gameObject = GetComponent<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
		void OnTriggerStay2D(Collider2D other){
		Debug.Log ("Collision");
		if (other.CompareTag ("Curve")) {
			Debug.Log ("Hej");
			int x = Random.Range (0, camera.pixelWidth);
			int y = Random.Range (0, camera.pixelHeight);
			Vector3 position = camera.ScreenToWorldPoint (new Vector3 (x, y, 0));
			position.Set (position.x, position.y, 0);

			transform.SetPositionAndRotation (position, new Quaternion ());
		}
	}
}
