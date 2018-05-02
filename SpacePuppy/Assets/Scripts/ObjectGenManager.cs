using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenManager : MonoBehaviour {
    public bool paused = false;
    float timer = 0f;
	public Camera camera;
	public Transform[] Placeholders;

	void Start () {
        SpawnObjects();
		}


	void Update () {
        if (!paused) { 
        timer += Time.deltaTime;
            if (timer > 8)
            {
                SpawnObjects();
                timer = 0f;
            }
        }
	}

    void SpawnObjects() {
        for (int i = 0; i < Placeholders.Length; i++)
        {
            int x = Random.Range(0, camera.pixelWidth);
            int y = Random.Range(0, camera.pixelHeight);

            Vector3 position = camera.ScreenToWorldPoint(new Vector3(x, y, 0));
            position.Set(position.x+20, position.y, 0);

            Placeholders[i].SetPositionAndRotation(position, new Quaternion());
        }
    }

}
