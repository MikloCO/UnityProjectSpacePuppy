using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenManager : MonoBehaviour
{
    public bool paused = false;
    public Camera cam;
    public Pause pause;
    public GameObject[] objects;
    public float[] timeBetweenSpawns = { 4, 8 };

    private float timer = 0f;
    private float timeUntilSpawn;

    void Start()
    {
        timeUntilSpawn = Random.Range(timeBetweenSpawns[0], timeBetweenSpawns[1]);
        SpawnObject();
    }


    void Update()
    {
        if (!paused)
        {
            timer += Time.deltaTime;
            if (timer > timeUntilSpawn)
            {
                SpawnObject();
                timer = 0f;
                timeUntilSpawn = Random.Range(timeBetweenSpawns[0], timeBetweenSpawns[1]);
            }
        }
    }

    private void SpawnObject()
    {
        int x = Random.Range(0, cam.pixelWidth);
        int y = Random.Range(0, cam.pixelHeight);

        Vector3 position = cam.ScreenToWorldPoint(new Vector3(x, y, 0));
        position.Set(position.x + 30f, position.y, 0);
        GameObject gO = objects[Random.Range(0, objects.Length)];
        Instantiate(gO, position, new Quaternion(), this.transform);
    }

}