using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_house : MonoBehaviour
{
    public player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");



            player.instance.transform.position = new Vector3(-103f, 15.4f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}

