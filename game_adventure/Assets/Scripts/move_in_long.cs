using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_long : MonoBehaviour
{
    public player player;
    public AudioManager audioManager;
    public EnemySpawner spawner;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");


            spawner.Kling = true;

            player.instance.transform.position = new Vector3(354.9f, -66.4f, 0f);
            Debug.Log("0");
            player.instance.is_in_dungeon = true;
            Debug.Log("1");

            player.instance.is_moving = false;

            Debug.Log("2");
            audioManager.change_music();
            Debug.Log("3");
            player.instance.targetPos = player.instance.transform.position;
            Debug.Log("4");

        }
    }
}
