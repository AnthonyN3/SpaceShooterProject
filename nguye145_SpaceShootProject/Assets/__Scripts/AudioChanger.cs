using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AudioChanger : MonoBehaviour
{
    //These 4 objects are the audio objects
    [Header("Object that hold Audio Source+Clip")]
    public GameObject musicObject;   //BackgroundMusicObject
    public GameObject blasterAudio;
    public GameObject enemyDestroyed;
    public GameObject clearStage;

    [Header("UI interactables")]
    public TMP_Dropdown musicDropDown;
    public Slider musicSlider;


    private static float musicVolume = 0.5f;
    private static int musicTypeIndex = 0;
    private static bool gameRanOnce = false;  //used to make sure the game doesnt replay a song when going back to menu

    void Awake()
    {
        //This is a MUST!!, since the musicObject is ran on "DoNotDestroyOnLoad", every time we move
        //from the game to the menu scene, we need to re-find the audio objects...(cannot just be done in inspector)    
        musicObject = GameObject.FindGameObjectWithTag("music");

        gameRanOnce = false;
        musicDropDown.value = musicTypeIndex;
        musicSlider.value = musicVolume;
        gameRanOnce = true;
    }

    //Used to change music volume (used with slider)
    public void MusicVolume(float value)
    {
        if(gameRanOnce) //Since the audio objects are on "DoNotDestroyOnLoad" we dont want to keep re running after every scene change
        {    
            musicObject.GetComponent<AudioSource>().volume = value;
            musicVolume = value;
        }
    }

    //Used to change the music (gives the index value from dropdown)
    public void MusicChange(int value)
    {
        if(gameRanOnce)
        {
            musicObject.GetComponent<BackgroundMusic>().ChangeMusic(value);
            musicTypeIndex = value;
        }
    }
}
