using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_out_pressis : MonoBehaviour
{
    public player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");



            player.instance.transform.position = new Vector3(23.41f, 44.83f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}