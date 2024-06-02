using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float time;
    
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("Destroying Wall");
            Destroy(this.gameObject);
        }
    }
}
