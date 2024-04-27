using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ItemEnum;

public class Item : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player player = collision.GetComponent<player>();
        if (player && this.type != CollectableType.PENN)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
                
        }
    }
}


namespace ItemEnum
{
    public enum CollectableType
    {
        NONE, COFFEE, BOOK, PENN
    }
}
