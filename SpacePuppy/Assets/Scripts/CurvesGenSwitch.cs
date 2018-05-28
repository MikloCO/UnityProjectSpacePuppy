using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour
{
    private Pause pause;

    public GameObject[] asteroidBeltDifficulty1;
    public GameObject[] asteroidBeltDifficulty2;
    public GameObject[] asteroidBeltDifficulty3;
    public GameObject[] asteroidBeltDifficulty4;
    public GameObject[] asteroidBeltDifficulty5;

    public float speed = 2f;
    public float endPosition = -30f;
    public float resetPosition = 30f;

    void Start()
    {
        pause = FindObjectOfType<Pause>();
        //Instantiate(asteroids[Random.Range(0, asteroids.Length)], this.transform);
        Instantiate(asteroidBeltDifficulty1[Random.Range(0, asteroidBeltDifficulty1.Length)], new Vector3(30, 0, 0), new Quaternion(), this.transform);
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
                GameObject oldBelt = otherChild.GetComponent<GameObject>();
                GameObject nextBelt = new GameObject();
                do {
                    switch (pause.difficulty) {
                        case 1:
                            nextBelt = asteroidBeltDifficulty1[Random.Range(0, asteroidBeltDifficulty1.Length)];
                            break;
                        case 2:
                            nextBelt = asteroidBeltDifficulty2[Random.Range(0, asteroidBeltDifficulty2.Length)];
                            break;
                        case 3:
                            nextBelt = asteroidBeltDifficulty3[Random.Range(0, asteroidBeltDifficulty3.Length)];
                            break;
                        case 4:
                            nextBelt = asteroidBeltDifficulty4[Random.Range(0, asteroidBeltDifficulty4.Length)];
                            break;
                        case 5:
                            nextBelt = asteroidBeltDifficulty5[Random.Range(0, asteroidBeltDifficulty5.Length)];
                            break;
                    }
                } while (oldBelt.Equals(nextBelt));
                Instantiate(nextBelt, (otherChild.position + Vector3.right * resetPosition), new Quaternion(), this.transform);
            }
        }
    }
}
