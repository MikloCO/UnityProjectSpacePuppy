using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;
    public CircleCollider2D lineCollider;
    public GameController gameController;

    public bool start = false;
    public bool end = false;
    public bool drawing = false;

    private bool mousePressed;
    private Vector3 mousePosition;
    private List<Vector3> vertexList = new List<Vector3>();

    public bool perfect = true;

    private void Start () {

    }

    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            mousePressed = true;
            RemoveLine();
        }

        if (mousePressed) {
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
            mousePressed = false;
            Finish();
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
        if(!end || !gameController.AllCoins()) {
            perfect = false;
        }
        start = false;
        drawing = false;
        RemoveLine();
        //gameController.FinishLevel();
    }

    private void RemoveLine () {
        lineRenderer.positionCount = 0;
        vertexList.RemoveRange(0, vertexList.Count);
    }
}
