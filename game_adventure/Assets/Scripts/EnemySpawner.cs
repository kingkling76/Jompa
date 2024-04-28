using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private bool canSpawn = true;
    public bool CastleSpawner;
    public bool ChurchPpawner;

    public bool OutOfSpawner;
    public bool Kling;

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
        if(ChurchPpawner && canSpawn)
        {

            Spawner(numEnemies);
        }
        if(Kling)
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
            Debug.Log("spawn");
        }

        // Stop spawning after spawning 10 enemies
        canSpawn = false;
        CastleSpawner = false;
        ChurchPpawner = false;
        Kling = false;
        OutOfSpawner = false;
    }
}
