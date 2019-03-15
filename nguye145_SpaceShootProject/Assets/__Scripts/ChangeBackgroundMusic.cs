using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusic : MonoBehaviour
{
    public GameObject objMusic;    //references the BackgroundMusic object

    void Awake()
    {
        if(objMusic == null)
            objMusic = GameObject.FindGameObjectWithTag("music");
    }

    //Used to change music volume (used with slider)
    public void SliderChange(float value)
    {
        objMusic.GetComponent<AudioSource>().volume = value;
    }

    //Used to change the music
    public void DropDown(int value)
    {
        objMusic.GetComponent<BackgroundMusic>().ChangeMusic(value);
    }

}
