using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBurst : MonoBehaviour {

    public GameObject clickBurst;

    private Vector3 mousePos;
    private Vector3 worldPos;

    private GameObject particles;


    void Start () {

        //mousePos = Input.mousePosition.x + Input.mousePosition.y;

        //        GetComponent<ParticleSystem>().emissionRate = 0;

        /* ParticleSystem pS = gO.transform.GetComponent<ParticleSystem>();
         pS.emissionRate = 0;*/

    } 
	
	void Update () {

       if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 2;

            worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            particles = (GameObject)Instantiate(clickBurst, worldPos, Quaternion.identity);

            Destroy(particles, .5f);
        }

		
	}
}
