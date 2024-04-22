using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public CollectableType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player player = collision.GetComponent<player>();

        if (player != null)
        {
            player.inventory.Add(type);
            Destroy(this.gameObject);
                
        }
    }
}

public enum CollectableType
{
    NONE, COFFEE
}
