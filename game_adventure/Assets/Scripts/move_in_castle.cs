using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_castle : MonoBehaviour
{
    public player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");



        player.instance.transform.position = new Vector3(11.33f, 138.25f, 0f);

        player.instance.is_moving = false;
        player.instance.targetPos = player.instance.transform.position;


    }
}
