using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInit : MonoBehaviour
{
    public player player;
    public EnemySpawner spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(EnemySpawner.BossSpawn < 1)
                EnemySpawner.BossSpawn++;
        }


    }
}
