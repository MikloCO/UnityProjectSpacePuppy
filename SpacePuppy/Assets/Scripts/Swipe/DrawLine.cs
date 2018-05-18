using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    
    public CircleCollider2D lineCollider;
    public SwipeController swipeController;
    private Pause pause;

    public float timeToDraw = 0.2f;

    public bool start = false;
    public bool end = false;
    public bool drawing = false;

    private bool mousePressed;
    private Vector3 mousePosition;

    private float drawTimer = 0f;

    public bool perfect = true;
    public bool failed = false;

	public GameObject particles;

    private void Start () {
        pause = FindObjectOfType<Pause>();
        particles.SetActive(false);
    }

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			mousePressed = true;
            particles.SetActive(true);
        }

		if (mousePressed) {
			drawTimer += Time.deltaTime;
			if(!start) {
				perfect = false;
			}
			drawing = true;
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = -1.3f;

            transform.position = mousePosition;
			particles.transform.position = mousePosition;
		}

		if (Input.GetMouseButtonUp(0)) {
			if(drawTimer >= timeToDraw) {
				Finish();
			}
            particles.SetActive(false);
            drawing = false;
            mousePressed = false;
			drawTimer = 0;
		}
	}


    public void SquiggleCollideBig (){
        mousePressed = false;
        failed = true;
        Finish();
    }

    public void SquiggleCollideSmall () {
        perfect = false;
    }

    public void Finish () {
        if(!end || !swipeController.AllCoins()) {
            perfect = false;
        }
        start = false;
        drawing = false;
        particles.SetActive(false);
        swipeController.Finish(perfect, failed);

        pause.Resume();
    }
}
