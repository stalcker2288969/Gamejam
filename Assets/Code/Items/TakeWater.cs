using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWater : MonoBehaviour
{
    public bool WaterTake;

    private bool _canNewUse = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerWall" && _canNewUse == true)
        {
            WaterTake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerWall" && _canNewUse == false)
        {
            _canNewUse = true;
        }
    }
}
