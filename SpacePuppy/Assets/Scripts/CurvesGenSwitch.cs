using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour {
    public bool paused = false;

<<<<<<< HEAD
    public GameObject[] asteroids;
    public Sprite[] sprites;
=======
    public GameObject[] astroids;

    public Sprite[] sprites;//Ta bort
>>>>>>> 83d2d0abc4b34bdc0f53f1347e5775628790d9ce
	public float speed = 2f;
	public float endPosition = -30f;
	public float resetPosition = 30f;
	public float background;
    

	void Start () {

	}


	void Update () {
        if (!paused) {
<<<<<<< HEAD
            for(int i = 0; i < 2; i++) {
                asteroids[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
=======
            int i = 0;
            for (int x = 0; x < 2; x++) {
                if (childs[i].position.x < endPosition) {
                    childs[i].position = new Vector3(resetPosition, 0, 0);

                    //Ta bort det här
                    childs[i].GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

                    //Lägg till att ni enablar ett gameobject från astroids och tar bort den som åkt ut ur bild
                    //Sätt det nya gameobjektet till rätt position och att den följer leadingsprite

                    if (leadingSprite == 0)
                        leadingSprite = 1;
                    else
                        leadingSprite = 0;
                }

                childs[leadingSprite].Translate(Vector3.left * speed * Time.deltaTime);

                if (leadingSprite == 0)
                    childs[1].position = childs[leadingSprite].position + Vector3.right * 30f;
                else
                    childs[0].position = childs[leadingSprite].position + Vector3.right * 30f;

                i++;
>>>>>>> 83d2d0abc4b34bdc0f53f1347e5775628790d9ce
            }
            //for (int x = 0; x < 2; x++) {
            //    if (children[i].position.x < endPosition) {
            //        // children[i].position = new Vector3(resetPosition, 0, 0);
            //        Destroy(children[i].GetComponent<GameObject>());
            //       // children[i].GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

            //        if (leadingSprite == 0)
            //            leadingSprite = 1;
            //        else
            //            leadingSprite = 0;
            //    }

            //    children[leadingSprite].Translate(Vector3.left * speed * Time.deltaTime);

            //    /if (leadingSprite == 0)
            //        children[1].position = children[leadingSprite].position + Vector3.right * 30f;
            //    else
            //        children[0].position = children[leadingSprite].position + Vector3.right * 30f;

            //    i++;
        }
	}
}
