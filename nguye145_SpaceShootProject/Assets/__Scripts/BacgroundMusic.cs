using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundMusic : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource musicSource;

    void Awake()
    {   
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("music");

        if(musicObject.Length > 1)
            Destroy(gameObject);

        //We need background music to be played between scenes
        DontDestroyOnLoad(this.gameObject); 
    }

    void Start()
    {
        Music(0);
    }

    public void Music(int musicIndex)
    {
        musicSource.clip = clips[musicIndex];
        musicSource.Play();
    }
}
