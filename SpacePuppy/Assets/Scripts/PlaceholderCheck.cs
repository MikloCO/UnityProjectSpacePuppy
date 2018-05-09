using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderCheck : MonoBehaviour {
    // Use this for initialization
    void Start () {
        GameObject gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag("Curve")) {
            int x = Random.Range(0, Camera.main.pixelWidth);
            int y = Random.Range(0, Camera.main.pixelHeight);
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            position.Set(position.x + 30f, position.y, 0);

            transform.SetPositionAndRotation(position, new Quaternion());
        }
    }
}
