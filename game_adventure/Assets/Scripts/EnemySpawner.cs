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
    public bool BossSpawn;

    public int numEnemies;

    private Coroutine spawnerCoroutine;

    private void Update()
    {
        if (CastleSpawner)
        {
            CastleSpawner_func(numEnemies, 0);
        }
        if (OutOfSpawner)
        {
            OutOfSpawner_func(numEnemies, 0);
        }
        if (ChurchPpawner)
        {

            ChurchSpawner_func(numEnemies, 0);
        }
        if (Kling)
        {
            KlingSpawner_func(numEnemies, 0);
        }
        if (BossSpawn == true)
        {
            BossSpawner_func(numEnemies, 1);
        }

    }

    /*
    private void Spawner(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }



        // Stop spawning after spawning 10 enemies
        canSpawn = false;
    }
    */
    public void CastleSpawner_func(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }
        CastleSpawner = false;

    }

    public void ChurchSpawner_func(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }
        ChurchPpawner = false;

    }

    public void KlingSpawner_func(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }
        Kling = false;

    }

    public void OutOfSpawner_func(int num, int index)
    {

        int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }
        OutOfSpawner = false;
    }


    public void BossSpawner_func(int num, int index)
    {

        /*int enemiesToSpawn = num; // Number of enemies to spawn
        if (enemiesToSpawn == 0) enemiesToSpawn = 1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            Debug.Log(enemyPrefab[index]);
            Instantiate(enemyPrefab[index], transform.position, Quaternion.identity);
        }
        BossSpawn++;
        */
        Instantiate(enemyPrefab[1], transform.position, Quaternion.identity);
        //BossSpawn;
        BossSpawn = false;

    }

}
