using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBurst : MonoBehaviour {

    /*   GameObject gO;
       GameObject mousePos; */

    public ParticleSystem clickBurst;
    
    

	// Use this for initialization
	void Start () {

        clickBurst.gameObject.SetActive(false);







        //        GetComponent<ParticleSystem>().emissionRate = 0;

        /* ParticleSystem pS = gO.transform.GetComponent<ParticleSystem>();
         pS.emissionRate = 0;*/

    } 
	
	// Update is called once per frame
	void Update () {

       if (Input.GetMouseButtonDown(0))
        {
            //pS.emissionRate = 10;
                clickBurst.gameObject.SetActive(true);

            Invoke("setFalse", 1f);
        }



 //       if(pS.enableEmission && Input.getMouseButton(0))

 //       if (Input.GetMouseButton(0))
   //     {
    //        GetComponent<ParticleSystem>().Emit(10);
     //   }
		
	}

    void setFalse()
    {
        if (clickBurst.gameObject.active)
        {
            clickBurst.gameObject.SetActive(false);
        }
    }
}
