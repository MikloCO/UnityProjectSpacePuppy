using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Sprite[] sprites;
	public float speed = 2f;

	void Update () {
		foreach (Transform tr in transform) {
			tr.Translate (Vector3.left * speed * Time.deltaTime);
			if (tr.position.x < -28) {
				Sprite sprite = sprites [Random.Range (0, sprites.Length)];
				tr.position = new Vector3 (sprite.bounds.size.x+28F, 0F, 0F);
				tr.GetComponent<SpriteRenderer> ().sprite = sprite;
			}
		}
	}
}
