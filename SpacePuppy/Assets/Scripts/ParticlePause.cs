using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePause : MonoBehaviour {

    private Pause pause;

    private bool paused = false;

    private void Start () {
        pause = FindObjectOfType<Pause>();
    }
    void Update () {
        if (pause.gameSpeed  == 0 && !paused){
            GetComponent<ParticleSystem>().Pause();
            paused = true;
        }
        if (pause.gameSpeed != 0 && paused) {
            GetComponent<ParticleSystem>().Play();
            paused = false;
        }
    }
}
