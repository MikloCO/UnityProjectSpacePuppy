using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonChange : MonoBehaviour {

    public Button currentButton;
    public Sprite musicOff;
    public Sprite musicOn;
    bool buttonPressed = false;

    Sprite myImageComponent;


    void Start () {

        musicOn = GetComponent<Sprite>();
        musicOff = GetComponent<Sprite>();
		
	}
	
	
	void Update () {
        
        if(buttonPressed == true)
        {

        }
    }
}
