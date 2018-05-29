using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScreenShow : MonoBehaviour {

    public GameObject[] gos;

	void Start () {
        switch (Movement.ctrl)
        {
            case Movement.ControllerType.HorizontalTouchRH:
                gos[1].SetActive(true);
                StartCoroutine(SetGoInactive(1));
                break;
            case Movement.ControllerType.HorizontalTouchLH:
                gos[0].SetActive(true);
                StartCoroutine(SetGoInactive(0));
                break;
            case Movement.ControllerType.VerticalTouch:
                gos[2].SetActive(true);
                StartCoroutine(SetGoInactive(2));
                break;
            case Movement.ControllerType.MoveTowardTouch:
                gos[3].SetActive(true);
                StartCoroutine(SetGoInactive(3));
                break;
        }
    }

    IEnumerator SetGoInactive(int i)
    {
        yield return new WaitForSeconds(5);
        gos[i].SetActive(false);
    }
}
