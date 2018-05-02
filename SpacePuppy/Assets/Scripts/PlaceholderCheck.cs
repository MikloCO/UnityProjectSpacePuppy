using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderCheck : MonoBehaviour {
    public Camera cam;
    // Use this for initialization
    void Start () {
        GameObject gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag("Curve")) {
            int x = Random.Range(0, cam.pixelWidth);
            int y = Random.Range(0, cam.pixelHeight);
            Vector3 position = cam.ScreenToWorldPoint(new Vector3(x, y, 0));
            position.Set(position.x + 30f, position.y, 0);

            transform.SetPositionAndRotation(position, new Quaternion());
        }
    }
}
