using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_church : MonoBehaviour
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

            player.instance.GodhetsP++;

            spawner.ChurchSpawner_func(10, 0);

            player.instance.transform.position = new Vector3(-68f, 71.8f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}
