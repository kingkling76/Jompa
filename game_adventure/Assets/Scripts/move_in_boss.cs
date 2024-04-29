using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_boss : MonoBehaviour
{
    public player player;
    public AudioManager audioManager;
    public Follower follower;
    public EnemySpawner spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");

            Destroy(follower);

            player.instance.transform.position = new Vector3(447.48f, -251.99f, 0f);
            player.instance.is_in_boss = true;
            //spawner.BossSpawner_func(1, 1);

            audioManager.change_music();

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }


    }
}

