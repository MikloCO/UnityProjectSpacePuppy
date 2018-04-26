using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour {
    public float speed = 1f;

	void Update () {
        //transform.Rotate(Vector3.right * Time.deltaTime);

        //transform.Rotate(Vector3.up, Time.deltaTime, Space.World);

        transform.Rotate(0, 0, speed * 0.01f);

    }
    public void Rotate() {
        
    }
}
