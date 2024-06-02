using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Noice : MonoBehaviour
{
    [SerializeField] float TimeToNoice;
    [SerializeField] ROOT ROOT;
    [SerializeField] AudioClip noiseClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(TimeToNoice > 0)
        {
            TimeToNoice -= Time.deltaTime;
        }
        else
        {
            ROOT.Patience += 3 * Time.deltaTime;
            PlayNoise();
        }
    }

    public void Off()
    { 
        if(TimeToNoice <= 0)
        {
            TimeToNoice = Random.Range(20f, 80f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerWall")
        {
            Off();
        }
    }

    private void PlayNoise()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.clip = noiseClip; 
            audioSource.Play(); 
        }
    }
}
