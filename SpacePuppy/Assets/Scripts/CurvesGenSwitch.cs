using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour {
    public bool paused = false;
    
    public GameObject[] asteroids;
    
	public float speed = 2f;
	public float endPosition = -30f;
	public float resetPosition = 30f;
	public float background;
    
	void Start () {

	}


	void Update () {
        if (!paused) {
            for (int i = 0; i < 2; i++) {
                int j;
                if(i == 0) {
                    j = 1;
                }
                else {
                    j = 0;
                }
                Transform thisChild = this.gameObject.transform.GetChild(i);
                Transform otherChild = this.gameObject.transform.GetChild(j);
                thisChild.Translate(Vector3.left * speed * Time.deltaTime);

                if(thisChild.position.x < endPosition) {
                    Destroy(thisChild.gameObject);
                    Instantiate(asteroids[Random.Range(0, 3)], (otherChild.position + Vector3.right * resetPosition), new Quaternion(), this.transform);
                }
            }
        }
	}
}
