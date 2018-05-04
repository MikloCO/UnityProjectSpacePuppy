using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {
    public Camera cam;
	public float speed = 2f;
    public bool paused = false;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            transform.Translate(Vector3.left * speed * 2f * Time.deltaTime);
        }
	}
    void CameraSize () { //Inte klar
        int x1 = 0;
        int y1 = 0;
        int x2 = cam.pixelWidth;
        int y2 = cam.pixelWidth;

        Vector3 position = cam.ScreenToWorldPoint(new Vector3(x1, y1, 0));
        position.Set(position.x + 30f, position.y, 0);
    }
}
