using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    private AudioSource menuAudio;
    //public Button MusicON;

    public AudioClip backMusic;
    public AudioClip click;

    void Start()
    {
        menuAudio = GetComponent<AudioSource>();
        menuAudio.PlayOneShot(backMusic, 1f); // bara när jag startar
        
    }

}