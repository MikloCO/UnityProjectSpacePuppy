using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float speed = 2f;
    public Pause pause;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.isVisible && pause.gameSpeed < 1f) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}