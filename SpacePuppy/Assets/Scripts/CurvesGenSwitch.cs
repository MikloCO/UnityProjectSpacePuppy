using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour
{
    private Pause pause;

    public GameObject[] asteroids;

    public float speed = 2f;
    public float endPosition = -30f;
    public float resetPosition = 30f;

    void Start()
    {
        pause = FindObjectOfType<Pause>();
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], this.transform);
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(30, 0, 0), new Quaternion(), this.transform);
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
                thisChild.Translate(Vector3.left * speed * pause.gameSpeed * pause.scoreSpeed * Time.deltaTime);
                otherChild.transform.position = new Vector3(thisChild.transform.position.x + 30f, otherChild.transform.position.y, otherChild.transform.position.z);
            }
            else
            {
                otherChild.Translate(Vector3.left * speed * pause.gameSpeed * pause.scoreSpeed * Time.deltaTime);
                thisChild.transform.position = new Vector3(otherChild.transform.position.x + 30f, thisChild.transform.position.y, thisChild.transform.position.z);
            }


            if (thisChild.position.x < endPosition)
            {
                Destroy(thisChild.gameObject);
                Instantiate(asteroids[Random.Range(0, asteroids.Length)], (otherChild.position + Vector3.right * resetPosition), new Quaternion(), this.transform);
            }
        }
    }
}
