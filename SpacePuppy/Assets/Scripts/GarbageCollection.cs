using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollection : MonoBehaviour {

    public Pause pause;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
        }
    }
}
