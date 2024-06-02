using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMan : MonoBehaviour
{
    public AudioSource ASource;
    public AudioClip[] Clips;

    void Start()
    {
        ASource.clip = Clips[Random.Range(0,Clips.Length)];
        ASource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(ASource.isPlaying == false)
        {
            ASource.clip = Clips[Random.Range(0, Clips.Length)];
            ASource.Play();
        }
    }
}
