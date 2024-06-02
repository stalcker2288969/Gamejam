using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagon : MonoBehaviour
{
    [SerializeField] Transform P1;
    [SerializeField] Transform P2;
    [SerializeField] Transform P3;
    [SerializeField] float Procent;
    [SerializeField] Transform Vag;
    [SerializeField] ROOT ROOT;
    [SerializeField] float dop;
   
    private bool _canNewUse = true;


    void Update()
    {
        Procent += Time.deltaTime;
        if (Procent < 100)
            Vag.position = Vector2.Lerp(P1.position, P2.position, Procent / 100);
        else
        {
            ROOT.Patience = 200;

            dop += Time.deltaTime;
            Vag.position = Vector2.Lerp(P2.position, P3.position, dop);
        }
    }

    void Off()
    {
        Procent = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerWall" && _canNewUse == true)
        {
            _canNewUse = false;
            Off();
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
