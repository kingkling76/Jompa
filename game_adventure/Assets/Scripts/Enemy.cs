using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public player player;
    public float speed;
    public int health;


    public void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.instance.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ShotBook"))
        {
            // If the collided object is a book, destroy the enemy
            health = health - 1;
            Destroy(other.gameObject);
            if (health <= 0) 
            {
                Destroy(this.gameObject);
            }

        }
        if (other.CompareTag("Penn"))
        {
            health = health - 1;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
