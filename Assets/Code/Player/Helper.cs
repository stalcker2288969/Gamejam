using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Transform PlayerPoint;


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else if (horizontalInput < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        transform.position = Vector2.Lerp(transform.position, PlayerPoint.position, Speed * Time.deltaTime);
    }

}
