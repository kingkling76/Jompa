using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private bool canSpawn = true;
    public bool CastleSpawner;
    public bool OutOfSpawner;
    public int numEnemies;

    private Coroutine spawnerCoroutine;

    private void Update()
    {
        if (CastleSpawner && canSpawn)
        {
            Spawner(numEnemies);
        }
        if (OutOfSpawner && canSpawn)
        {
            Spawner(numEnemies);
        }


    }

    private void Spawner(int num)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[0], transform.position, Quaternion.identity);
        }

        // Stop spawning after spawning 10 enemies
        canSpawn = false;
        CastleSpawner = false;
        OutOfSpawner = false;
    }
}
