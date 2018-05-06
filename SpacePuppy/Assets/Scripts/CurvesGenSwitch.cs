using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour
{
    //public bool paused = false;
    public Pause paus;


    public GameObject[] asteroids;

    public float speed = 2f;
    public float endPosition = -30f;
    public float resetPosition = 30f;
    //public float background;

    void Start()
    {
        //   float f = Mathf.Lerp(transform.position.y, asteroids[1].transform.position.y, 0.4f);

        // totala längden mellan de två punkternas x-led
        // hur långt har spelaren kommit i x-led från första punktens x-led
    }


    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            int j;
            if (i == 0)
            {
                j = 1;
            }
            else
            {
                j = 0;
            }
            Transform thisChild = this.gameObject.transform.GetChild(i);
            Transform otherChild = this.gameObject.transform.GetChild(j);

            if (thisChild.transform.position.x < otherChild.transform.position.x)
            {
                thisChild.Translate(Vector3.left * speed * paus.gameSpeed * Time.deltaTime);
                otherChild.transform.position = new Vector3(thisChild.transform.position.x + 30f, otherChild.transform.position.y, otherChild.transform.position.z);
            }
            else
            {
                otherChild.Translate(Vector3.left * speed * paus.gameSpeed * Time.deltaTime);
                thisChild.transform.position = new Vector3(otherChild.transform.position.x + 30f, thisChild.transform.position.y, thisChild.transform.position.z);
            }


            if (thisChild.position.x < endPosition)
            {
                Destroy(thisChild.gameObject);
                Instantiate(asteroids[Random.Range(0, 5)], (otherChild.position + Vector3.right * resetPosition), new Quaternion(), this.transform);
            }
        }
    }
}
