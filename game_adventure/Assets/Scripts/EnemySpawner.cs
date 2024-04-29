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
    public static int BossSpawn =0;

    public int numEnemies;

    private Coroutine spawnerCoroutine;

    private void Update()
    {
        if (CastleSpawner && canSpawn)
        {
            Spawner(numEnemies, 0);
        }
        if (OutOfSpawner && canSpawn)
        {
            Spawner(numEnemies, 0);
        }
        if(ChurchPpawner && canSpawn)
        {

            Spawner(numEnemies, 0);
        }
        if(Kling)
        {
            Spawner(numEnemies, 0);
        }
        if (BossSpawn == 1)
        {
            Spawner(numEnemies,1);
        }

    }

    private void Spawner(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if(enemiesToSpawn == 0) enemiesToSpawn=1;
        Debug.Log("Enemies to spawn");
        Debug.Log(enemiesToSpawn);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
            Debug.Log("sadana");
        }

        // Stop spawning after spawning 10 enemies
        canSpawn = false;
        CastleSpawner = false;
        ChurchPpawner = false;
        Kling = false;
        OutOfSpawner = false;
        BossSpawn++;
    }
}
