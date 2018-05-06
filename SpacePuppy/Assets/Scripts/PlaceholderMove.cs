using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderMove : MonoBehaviour
{
    public float speed = 2f;
    private Pause paused;

    // Use this for initialization
    void Start()
    {
        paused = FindObjectOfType<Pause>();
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            transform.Translate(Vector3.left * speed * paused.gameSpeed * 2f * Time.deltaTime);
        }
    }
}