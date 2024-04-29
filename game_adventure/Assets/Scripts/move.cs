using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public player player;
    public EnemySpawner spawner;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioManager.do_clip_door();
            Debug.Log("jalla");

            spawner.OutOfSpawner_func(5,0);

            player.instance.transform.position = new Vector3(-44.5f, -4.5f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}
