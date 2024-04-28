using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_out_long : MonoBehaviour
{
    public player player;

    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");
        if (other.tag == "Player")
        {



            player.instance.transform.position = new Vector3(127.3f, 33.84f, 0f);
            player.instance.is_in_dungeon = false;
            player.instance.is_moving = false;
            audioManager.change_music();
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}
