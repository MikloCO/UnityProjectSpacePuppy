using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {
    public Camera cam;
	public float speed = 2f;
<<<<<<< HEAD:SpacePuppy/Assets/Scripts/PlaceholderMove.cs
    private Pause paused;

	// Use this for initialization
	void Start () {
        paused = FindObjectOfType<Pause>();
		Transform transform = GetComponent<Transform> ();
=======
    public bool paused = false;
    

	// Use this for initialization
	void Start () {

>>>>>>> 6590b89a7c7500336969f76b77c80992fa8e519c:SpacePuppy/Assets/Scripts/AsteroidMove.cs
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            transform.Translate(Vector3.left * speed * paused.gameSpeed * 2f * Time.deltaTime);
        }
	}
    void CameraSize () { //Inte klar
        int x1 = 0;
        int y1 = 0;
        int x2 = cam.pixelWidth;
        int y2 = cam.pixelWidth;

        Vector3 position = cam.ScreenToWorldPoint(new Vector3(x1, y1, 0));
        position.Set(position.x + 30f, position.y, 0);
    }
}
