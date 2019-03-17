using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterAudio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource blasterSource;

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
        blasterSource.clip = clips[0];
    }

    public void ChangeBlasterAudio(int blasterIndex)
    {
        blasterSource.clip = clips[blasterIndex];
        PlayBlasterAudio();
    }

    public void PlayBlasterAudio()
    {
        blasterSource.Play();
    }
}
