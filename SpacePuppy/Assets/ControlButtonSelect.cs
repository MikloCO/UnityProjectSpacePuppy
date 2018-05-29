using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButtonSelect : MonoBehaviour {

    public Button[] buttons;
    public Image[] selectedSprites;

    void Start()
    {
        switch (Movement.ctrl)
        {
            case Movement.ControllerType.HorizontalTouchRH:
                buttons[0].image = selectedSprites[0];
                break;
            case Movement.ControllerType.HorizontalTouchLH:
                buttons[1].image = selectedSprites[1];
                break;
            case Movement.ControllerType.VerticalTouch:
                buttons[2].image = selectedSprites[2];
                break;
            case Movement.ControllerType.MoveTowardTouch:
                buttons[3].image = selectedSprites[3];
                break;
        }
    }
    

    
}
