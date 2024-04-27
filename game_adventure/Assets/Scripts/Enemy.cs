using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject enemyPrefab;
    private player player;
    private Vector2 spawn;

    // Constructor for setting initial values
    public Enemy(int health, float speed, Vector2 spawn)
    {
        this.health = health;
        this.speed = speed;
        this.spawn = spawn;
    }

    // Method for instantiating the enemy prefab
    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawn, Quaternion.identity);
        // You can further customize the instantiated enemy here, like setting its health, speed, etc.
    }



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
