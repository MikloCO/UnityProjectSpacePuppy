using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour {

    public Pause pause;
    public GameObject[] asteroids;
    public float chanceToSpawn = 50F;

    // Use this for initialization
    void Start () {
        float random = Random.Range(0F, 100F);
        if (random < chanceToSpawn) {
            Spawn();
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Spawn () {
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], transform);
    }

}
