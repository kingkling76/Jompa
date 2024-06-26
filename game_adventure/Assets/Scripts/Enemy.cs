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
    public AudioManager audioManager;
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
        GameObject enemyPrefab = Resources.Load<GameObject>("Enemy"); // Assuming you have an enemy prefab named "EnemyPrefab"
        Instantiate(enemyPrefab, spawn, Quaternion.identity);

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
            audioManager.do_clip_hurt();
            // If the collided object is a book, destroy the enemy
            health = health - 1;
            Destroy(other.gameObject);
            if (health <= 0) 
            {
                if (this.CompareTag("Boss")) player.instance.Win();
                Destroy(this.gameObject);
            }

        }
        if (other.CompareTag("Penn"))
        {
            audioManager.do_clip_hurt();
            health = health - 1;
            if (health <= 0)
            {
                if (this.CompareTag("Boss")) player.instance.Win();
                Destroy(this.gameObject);
            }
        }
    }
}
