using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.W))
        {
            anim.SetInteger("state", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetInteger("state", 2);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("state", 0);
        }
    }

}