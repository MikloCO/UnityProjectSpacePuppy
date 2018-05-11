using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDCPath : MonoBehaviour {

    public GameObject[] dcPaths;
    public float chanceToSpawn = 50F;

    void Start () {
        float random = Random.Range(0F, 100F);
        if (random > chanceToSpawn) {
            Destroy(gameObject);
        }
    }
}
