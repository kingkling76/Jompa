using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tmuseet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.instance.GodhetsP++;
            

        }

    }

}
