using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_out_castle : MonoBehaviour
{
    public player player;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("jalla");
            audioManager.do_clip_door();


            player.instance.GodhetsP++;

            player.instance.transform.position = new Vector3(61.04f, 73.54f, 0f);

            player.instance.is_moving = false;
            player.instance.targetPos = player.instance.transform.position;
        }

    }
}