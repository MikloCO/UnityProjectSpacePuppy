using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {
	public Sprite[] sprites;
	public float speed = 2f;
	public float endPosition = -30f;
	public float resetPosition = 30f;
	public float background;

	private Transform[] childs;
	int leadingSprite = 0;

	void Start () {
		childs = UtilityExtensions.GetComponentsOnlyInChildren<Transform>(this); 
	}


	void Update () {
		int i = 0;
		for (int x=0;x<2;x++) {
			if (childs[i].position.x < endPosition) {
				childs[i].position = new Vector3 (resetPosition, 0, 0);

				childs [i].GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, sprites.Length)];

				if (leadingSprite == 0)
					leadingSprite = 1;
				else
					leadingSprite = 0;
			}

			childs[leadingSprite].Translate (Vector3.left * speed * Time.deltaTime);

			if(leadingSprite==0)
				childs [1].position = childs [leadingSprite].position + Vector3.right * 30f;
			else 
				childs [0].position = childs [leadingSprite].position + Vector3.right * 30f;

			i++;
		}
	}
}
