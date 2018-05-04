using UnityEngine;

public class RotatingScript : MonoBehaviour {

    public Pause paus;
    public float speed = 1f;

	void Update () {
        transform.Rotate(0, 0, speed * 0.01f * paus.gameSpeed);
    }
}
