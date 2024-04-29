using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInit : MonoBehaviour
{
    public player player;
    public EnemySpawner spawner;
    public Enemy Boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spawner.BossSpawner_func(1,1);

        }
        Boss.health = 50 - 10 *player.instance.GodhetsP;

        Destroy(this.gameObject);
    }

}
