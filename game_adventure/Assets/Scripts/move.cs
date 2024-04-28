using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public player player;
    public EnemySpawner spawner;
    public StoryManager storyManager;
    public static int p = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("jalla");

        if (other.tag == "Player")
        {
            spawner.OutOfSpawner = true;

            player.instance.transform.position = new Vector3(-44.5f, -4.5f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
            if (p == 0)
            {
                StoryManager.instance.Quest1();
                p = 1;
            }
        }

    }
}
