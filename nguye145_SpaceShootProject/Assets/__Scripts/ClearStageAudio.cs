using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStageAudio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource winAudio;

    void Awake()
    {   
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("WinAudio");

        if(musicObject.Length > 1)
            Destroy(gameObject);

        //We need background music to be played between scenes
        DontDestroyOnLoad(this.gameObject); 
    }

    void Start()
    {
        winAudio.clip = clips[0];
    }

    public void ChangeWinAudio(int killIndex)
    {
        winAudio.clip = clips[killIndex];
        PlayWinAudio();
    }

    public void PlayWinAudio()
    {
        winAudio.Play();
    }
}
