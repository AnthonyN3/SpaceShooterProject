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
    public GameObject blasterAudio; //the object that contains the Audio Source for playing the blasters
    public GameObject enemyDestroyedAudio;
    public GameObject clearStageAudio;

    [Header("UI interactables")]
    public TMP_Dropdown musicDropDown;
    public Slider musicSlider;
    public TMP_Dropdown blasterDropDown;
    public Slider blasterSlider;
    public TMP_Dropdown destroyDropDown;
    public Slider destroySlider;
    public TMP_Dropdown winDropDown;
    public Slider winSlider;

    private static float musicVolume = 0.5f;
    private static int musicTypeIndex = 0;
    private static bool gameRanOnce = false;  //used to make sure the game doesnt replay a song when going back to menu

    private static float blasterVolume = 0.5f;
    private static int blasterTypeIndex = 0;
    private static float destroyVolume = 0.5f;
    private static int destroyTypeIndex = 0;
    private static float winVolume = 0.5f;
    private static int winTypeIndex = 0;

    void Awake()
    {
        //This is a MUST!!, since the musicObject is ran on "DoNotDestroyOnLoad", every time we move
        //from the game to the menu scene, we need to re-find the audio objects...(cannot just be done in inspector)    
        musicObject = GameObject.FindGameObjectWithTag("music");
        blasterAudio = GameObject.FindGameObjectWithTag("BlasterAudio");
        enemyDestroyedAudio = GameObject.FindGameObjectWithTag("EnemyDestroyedAudio");
        clearStageAudio = GameObject.FindGameObjectWithTag("WinAudio");

        gameRanOnce = false;

        musicDropDown.value = musicTypeIndex;
        musicSlider.value = musicVolume;

        blasterDropDown.value = blasterTypeIndex;
        blasterSlider.value = blasterVolume;

        destroyDropDown.value = destroyTypeIndex;
        destroySlider.value = destroyVolume;

        winDropDown.value = winTypeIndex;
        winSlider.value = winVolume;

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

    public void BlasterVolume(float value)
    {
        blasterAudio.GetComponent<AudioSource>().volume = value;
        blasterVolume = value;

        //blasterAudio.GetComponent<BlasterAudio>().PlayBlasterAudio();
    }

    public void BlasterChange(int value)
    {
        if(gameRanOnce)
        {
            blasterAudio.GetComponent<BlasterAudio>().ChangeBlasterAudio(value);
            blasterTypeIndex = value;

            blasterAudio.GetComponent<BlasterAudio>().PlayBlasterAudio();
        }
    }

    public void DestroyVolume(float value)
    {
        enemyDestroyedAudio.GetComponent<AudioSource>().volume = value;
        destroyVolume = value;
    }
    public void DestroyChange(int value)
    {
        if(gameRanOnce)
        {
            enemyDestroyedAudio.GetComponent<EnemyKilledAudio>().ChangeKillAudio(value);
            destroyTypeIndex = value;
        
            enemyDestroyedAudio.GetComponent<EnemyKilledAudio>().PlayEnemyDeathAudio();            
        }
    }

    public void WinVolume(float value)
    {
        clearStageAudio.GetComponent<AudioSource>().volume = value;
        winVolume = value;
    }
    public void WinChange(int value)
    {
        if(gameRanOnce)
        {
            clearStageAudio.GetComponent<ClearStageAudio>().ChangeWinAudio(value);
            winTypeIndex = value;
        
            clearStageAudio.GetComponent<ClearStageAudio>().PlayWinAudio();            
        }
    }

}
