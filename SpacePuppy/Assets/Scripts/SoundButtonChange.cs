using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonChange : MonoBehaviour {

    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private int count = 0;


    // private bool soundOn = false;
    // private SpriteRenderer spr;

    /*
   public Button currentButton;
    public Sprite musicOff;
    public Sprite musicOn;
    bool buttonPressed = false;
    */
    //Sprite myImageComponent; 


    void Start () {

        // spr = GetComponent<SpriteRenderer>();
        soundButton = GetComponent<Button>();

        //spr.sprite = soundOnSprite;

        // musicOn = GetComponent<Sprite>();
        // musicOff = GetComponent<Sprite>();

    }


    void Update () {

      //  soundButton.onClick.ChangeButton();

    }

    public void ChangeButton()
    {

     //   soundButton.onClick()= count++;

        if(count%2 == 0)
        {
            soundButton.image.overrideSprite = soundOnSprite;
        }
        else
        {
            soundButton.image.overrideSprite = soundOffSprite;
        }
        /*
        if(spr.sprite == soundOnSprite)
        {
            spr.sprite = soundOffSprite;
        }
        else
        {
            spr.sprite = soundOnSprite;
        }
        */
    }
   
}
