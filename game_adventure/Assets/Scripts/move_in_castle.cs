using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_in_castle : MonoBehaviour
{
    public player player;
    public EnemySpawner spawner;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");


            audioManager.do_clip_door();

            player.instance.transform.position = new Vector3(11.33f, 138.25f, 0f);

            //spawner.CastleSpawner = true;
            spawner.CastleSpawner_func(15,0);



            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }
        /*
        Vector2 blabla = new Vector2(6.68f, 140.9f);
        Enemy p = new Enemy(1, 10, blabla);
        p.SpawnEnemy();
        
    */

     }
}
