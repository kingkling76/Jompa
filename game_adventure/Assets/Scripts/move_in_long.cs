using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_long : MonoBehaviour
{
    public player player;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");



        player.instance.transform.position = new Vector3(354.9f, -66.4f, 0f);
        player.instance.is_in_dungeon = true;
        player.instance.is_moving = false;
        audioManager.change_music();
        player.instance.targetPos = player.instance.transform.position;


    }
}
