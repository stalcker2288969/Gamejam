using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Move;
    [SerializeField] private float JumpForce;
    [SerializeField] AudioClip RunNoice;
    [SerializeField] AudioClip JumpNoice;
    private AudioSource audioSource;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private bool _helpJump = false;
    private float _time;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(horizontalInput * Speed, _rigidbody.velocity.y);
        
        if (horizontalInput > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else if (horizontalInput < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            if(_isGrounded)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                PlayNoise(JumpNoice);
            }
            else if (!_isGrounded)
            {
                _helpJump = true;
                _time = 0.3f;
            }
        }

        _time = _time > 0 ? _time - Time.deltaTime : 0;
        if(_time <= 0)
            _helpJump = false;

        if((horizontalInput > 0 || horizontalInput < 0) && _isGrounded == true && audioSource.isPlaying == false)
        {
            PlayNoise(RunNoice);
        }
        else if(horizontalInput == 0)
        {
            audioSource.Stop();
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (_helpJump == true)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            PlayNoise(JumpNoice);
            _helpJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void PlayNoise(AudioClip audioClip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
