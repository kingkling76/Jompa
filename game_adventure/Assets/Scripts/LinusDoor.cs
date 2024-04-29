using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinusDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Penn" || other.tag == "ShotBook" && !player.instance.HasHelpedLinus)
        {            
            player.instance.GodhetsP++;
            player.instance.HasHelpedLinus = true;

        }

    }
}
