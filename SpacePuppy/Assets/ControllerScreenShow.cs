using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScreenShow : MonoBehaviour {

    public GameObject[] gos;

	void Start () {
        switch (PlayerPrefs.GetInt("Controls"))
    public void Start()
    {
        switch (Movement.ctrl)
        {
            case 2:
                gos[1].SetActive(true);
                StartCoroutine(SetGoInactive(1));
                break;
            case 3:
                gos[0].SetActive(true);
                StartCoroutine(SetGoInactive(0));
                break;
            case 0:
                gos[2].SetActive(true);
                StartCoroutine(SetGoInactive(2));
                break;
            case 1:
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
