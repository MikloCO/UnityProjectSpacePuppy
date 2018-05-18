using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {
    public float speed = 2f;
    private Pause pause;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        pause = FindObjectOfType<Pause>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

        if (sprite.isVisible) {
            transform.Translate(Vector3.left * speed * pause.gameSpeed * Time.deltaTime);
        }
    }
}