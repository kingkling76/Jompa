using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");

        
       
        player.instance.transform.position = new Vector3(-44.5f, -4.5f, 0f);

        player.instance.is_moving = false;
        player.instance.targetPos = player.instance.transform.position;


    }
}
