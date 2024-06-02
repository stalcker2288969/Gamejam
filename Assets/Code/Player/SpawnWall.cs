using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField] private GameObject Wall;
    [SerializeField] private Transform SpawnPos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            var w = Instantiate(Wall, SpawnPos.position, new Quaternion());
        }
    }
}