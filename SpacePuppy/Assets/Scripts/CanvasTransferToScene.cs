using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTransferToScene : MonoBehaviour {

    public GameObject scoresMenu;
    public GameObject menu;
    public GameObject title;


    void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

    public void MoveToNextScene () {
        Destroy(scoresMenu);
        Destroy(menu);
        Destroy(title);
    }
}
