﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePause : MonoBehaviour {

    public Pause pause;

    private bool paused = false;

	// Update is called once per frame
	void Update () {
        if (pause.gameSpeed == 0 && !paused){
            GetComponent<ParticleSystem>().Pause();
            paused = true;
        }
        if (pause.gameSpeed != 0 && paused) {
            GetComponent<ParticleSystem>().Play();
            paused = false;
        }
    }
}
