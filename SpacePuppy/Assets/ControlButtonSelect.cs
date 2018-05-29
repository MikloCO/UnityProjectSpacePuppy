using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonSelect : MonoBehaviour {

    public Button[] buttons;
    public Sprite[] selectedSprites;

    void Start()
    {
        switch (Movement.ctrl)
        {
            case Movement.ControllerType.VerticalTouch:
                buttons[0].GetComponent<Image>().sprite = selectedSprites[0];
                break;
            case Movement.ControllerType.MoveTowardTouch:
                buttons[1].GetComponent<Image>().sprite = selectedSprites[1];
                break;
            case Movement.ControllerType.HorizontalTouchLH:
                buttons[2].GetComponent<Image>().sprite = selectedSprites[2];
                break;
            case Movement.ControllerType.HorizontalTouchRH:
                buttons[3].GetComponent<Image>().sprite = selectedSprites[3];
                break;
        }
    }
    
    public void SetControllerType (int control) {
        Movement.SetControllerType(control);
    }
    
}
