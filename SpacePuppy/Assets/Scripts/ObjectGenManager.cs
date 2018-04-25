using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenManager : MonoBehaviour {

	public Camera camera;
	public Transform[] Placeholders;

	void Start () {
		for (int i = 0; i < Placeholders.Length; i++){
			int x = Random.Range (0, camera.pixelWidth);
			int y = Random.Range (0, camera.pixelHeight);

			Vector3 position = camera.ScreenToWorldPoint(new Vector3(x,y,0));
			position.Set (position.x, position.y, 0);

			Placeholders[i].SetPositionAndRotation(position, new Quaternion());
		}
		}


	void Update () {

	}
}
