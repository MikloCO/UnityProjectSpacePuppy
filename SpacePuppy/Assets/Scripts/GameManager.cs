using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Sprite[] sprites;
	public float speed = 2f;
	public float endPosition = 36f;
	public float resetPosition = 72f;

	void Update () {
		foreach (Transform tr in transform) {
			tr.Translate (Vector3.left * speed * Time.deltaTime);
			if (tr.position.x < -endPosition) {
				Sprite sprite = sprites [Random.Range (0, sprites.Length)];
				//tr.position = new Vector3 (sprite.bounds.size.x+endPosition, 0F, 0F);
				tr.position = new Vector3 (resetPosition, 0F, 0F);
				tr.GetComponent<SpriteRenderer> ().sprite = sprite;
			}
		}
	}
}
