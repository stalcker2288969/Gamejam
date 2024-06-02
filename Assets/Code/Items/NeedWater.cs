using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NeedWater : MonoBehaviour
{
    public TakeWater TW;
    [SerializeField] float TimeToWater;
    [SerializeField] ROOT ROOT;
    [SerializeField] AudioClip noiseClip;
    private bool _canNewUse = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    private void Update()
    {
        if(TimeToWater > 0) 
        {
            TimeToWater -= Time.deltaTime;
            TW.WaterTake = false;
        }
        else
        {
            ROOT.Patience += 3 * Time.deltaTime;
            PlayNoise();
        }
    }

    public void Off()
    {
        TimeToWater = Random.Range(30f, 120f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (TimeToWater <= 0 && TW.WaterTake == true)
        {
            if (collision.gameObject.tag == "PlayerWall" && _canNewUse)
            {
                _canNewUse = false;
                Off();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWall" && _canNewUse == false)
        {
            _canNewUse = true;
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
