using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Transform PlayerPoint;

    private void Update()
    {
        Vector3 targetPosition = PlayerPoint.position + new Vector3(0, 1);
        targetPosition.z = transform.position.z; // Set the z-coordinate to the camera's current z-coordinate

        transform.position = Vector3.MoveTowards(transform.position,
            targetPosition,
            Speed * Time.deltaTime);
    }
}
