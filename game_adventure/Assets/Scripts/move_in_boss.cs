using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_boss : MonoBehaviour
{
    public player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");



        player.instance.transform.position = new Vector3(447.48f, -251.99f, 0f);

        player.instance.is_moving = false;
        player.instance.targetPos = player.instance.transform.position;


    }
}

