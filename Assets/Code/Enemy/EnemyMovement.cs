using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float Speed;
    [SerializeField] private int _currentPoint;

    public void SetPoints(Transform[] points)
    {
        this.points = points;
        _currentPoint = 0;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[_currentPoint].position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == points[_currentPoint].name)
        {
            Debug.Log("Касание");
            _currentPoint += 1;
            if(_currentPoint >= points.Length)
            {
                _currentPoint = 0;             
            }
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
