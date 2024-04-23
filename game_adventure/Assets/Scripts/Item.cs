using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player player = collision.GetComponent<player>();
        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
                
        }
    }
}

public enum CollectableType
{
    NONE, COFFEE
}
