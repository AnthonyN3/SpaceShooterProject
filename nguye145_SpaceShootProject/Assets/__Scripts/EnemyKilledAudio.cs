using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledAudio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource killAudio;

    void Awake()
    {   
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("EnemyDestroyedAudio");

        if(musicObject.Length > 1)
            Destroy(gameObject);

        //We need background music to be played between scenes
        DontDestroyOnLoad(this.gameObject); 
    }

    void Start()
    {
        killAudio.clip = clips[0];
    }

    public void ChangeKillAudio(int killIndex)
    {
        killAudio.clip = clips[killIndex];
        PlayEnemyDeathAudio();
    }

    public void PlayEnemyDeathAudio()
    {
        killAudio.Play();
    }
}
