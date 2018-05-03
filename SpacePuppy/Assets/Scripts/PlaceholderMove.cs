using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMove : MonoBehaviour {
	public float speed = 2f;
    public bool paused = false;

	// Use this for initialization
	void Start () {
		Transform transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            transform.Translate(Vector3.left * speed * 2f * Time.deltaTime);
        }
	}
}
