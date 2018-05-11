using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePause : MonoBehaviour {

    public Pause pause;

    private bool paused = false;

	void Update () {
        if (pause.gameSpeed < 0.3 && !paused){
            GetComponent<ParticleSystem>().Pause();
            paused = true;
        }
        if (pause.gameSpeed > 0.3 && paused) {
            GetComponent<ParticleSystem>().Play();
            paused = false;
        }
    }
}
