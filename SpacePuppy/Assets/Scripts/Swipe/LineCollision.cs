using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollision : MonoBehaviour {

    public SwipeController swipeController;
    public Collider2D startCollider;
    public Collider2D endCollider;

    private void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (startCollider.OverlapPoint(mousePosition))
            transform.parent.GetComponent<DrawLine>().start = true;
        else if (!transform.parent.GetComponent<DrawLine>().drawing){
            transform.parent.GetComponent<DrawLine>().start = false;
        }

        if (endCollider.OverlapPoint(mousePosition)) {
            transform.parent.GetComponent<DrawLine>().end = true;
        }
        else {
            transform.parent.GetComponent<DrawLine>().end = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("CoinCircle")) {
            Vector3 position = other.GetComponent<Transform>().position;
            if (GetComponentInParent<DrawLine>().drawing == true && !swipeController.coinPositions.Contains(position)) {
                swipeController.AddCoin(position);
            }
        }
    }

}