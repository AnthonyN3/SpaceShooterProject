using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundMusic : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource musicSource;

    void Awake()
    {   

        
        //We need background music to be played between scenes
        DontDestroyOnLoad(this.gameObject); 
    }

    public void Music(int musicIndex)
    {
        musicSource.clip = clips[musicIndex];
        musicSource.Play();
    }
}
