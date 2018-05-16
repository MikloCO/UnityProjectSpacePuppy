using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Movement player;
    public GameObject[] heads;

	// Use this for initialization
	void Start () {
		
	}
	public void Damage()
    {
        heads[2].SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
