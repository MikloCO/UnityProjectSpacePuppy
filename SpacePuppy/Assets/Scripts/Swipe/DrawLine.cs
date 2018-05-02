using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;
    public CircleCollider2D lineCollider;
    public SwipeController swipeController;
    public Pause pause;

    public float timeToDraw = 0.4f;

    public bool start = false;
    public bool end = false;
    public bool drawing = false;

    private bool mousePressed;
    private Vector3 mousePosition;
    private List<Vector3> vertexList = new List<Vector3>();

    private float drawTimer = 0f;

    public bool perfect = true;

    private void Start () {

    }

    void Update () {
        Debug.Log(perfect);
        if (Input.GetMouseButtonDown(0)) {
            mousePressed = true;
            RemoveLine();
        }

        if (mousePressed) {
            drawTimer += Time.deltaTime;
            if(!start) {
                perfect = false;
            }
            drawing = true;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (!vertexList.Contains(mousePosition)) {
                vertexList.Add(mousePosition);
                lineRenderer.positionCount = vertexList.Count;
                lineRenderer.SetPosition(vertexList.Count - 1, vertexList[vertexList.Count - 1]);
                lineCollider.transform.position = vertexList[vertexList.Count - 1];
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if(drawTimer >= timeToDraw) {
                Finish();
            }
            mousePressed = false;
            drawTimer = 0;
        }
	}

    public void SquiggleCollideBig (){
        mousePressed = false;
        start = false;
        drawing = false;
        RemoveLine();
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
        RemoveLine();

        pause.Resume();
    }

    private void NextLevel () {
        swipeController.NextLevel();
    }

    private void RemoveLine () {
        lineRenderer.positionCount = 0;
        vertexList.RemoveRange(0, vertexList.Count);
    }
}
