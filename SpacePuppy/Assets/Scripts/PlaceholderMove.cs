using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMove : MonoBehaviour {
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		Transform transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(-speed,0,0), transform);
	}
}
