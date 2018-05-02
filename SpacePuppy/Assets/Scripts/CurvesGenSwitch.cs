using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurvesGenSwitch : MonoBehaviour {
    public bool paused = false;

    public GameObject[] asteroids;
    public Sprite[] sprites;
	public float speed = 2f;
	public float endPosition = -30f;
	public float resetPosition = 30f;
	public float background;
    

	void Start () {

	}


	void Update () {
        if (!paused) {
            for(int i = 0; i < 2; i++) {
                asteroids[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
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
