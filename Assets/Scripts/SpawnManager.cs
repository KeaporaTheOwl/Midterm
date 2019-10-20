using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public GameObject enemyFighters;
    public GameObject bossSummoner;
    private int initialEnemiesSpawned;
    private int initialAsteroidsSpawned;
    private int enemiesSpawned;
    private int asteroidsSpawned;
    private float spawnRangeX = 150;
    private float spawnRangeZ = 150;
    private float initialEnemySpawnRangeX = 150;
    private float initialEnemySpawnRangeZ = 150;
    private float enemySpawnTime;
    private float enemySpawnDelay = 10;
    private float asteroidSpawnTime;
    private float asteroidSpawnDelay = 15;

    // Start is called before the first frame update
    void Start()
    {
        while (initialEnemiesSpawned < 20)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-initialEnemySpawnRangeX, initialEnemySpawnRangeX), 0, Random.Range(-initialEnemySpawnRangeZ, initialEnemySpawnRangeZ));
            Instantiate(enemyFighters, spawnPos, transform.rotation);
            initialEnemiesSpawned++;
        }

        while (initialAsteroidsSpawned < 1000)
        {
            int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPosTwo = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(asteroidPrefabs[asteroidIndex], spawnPosTwo, Random.rotation);
            initialAsteroidsSpawned++;
        }

        Vector3 spawnPosThree = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(bossSummoner, spawnPosThree, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > enemySpawnTime + enemySpawnDelay)
        {
            enemySpawnTime = Time.time;
            spawnEnemies();
        }

        if (Time.time > asteroidSpawnTime + asteroidSpawnDelay)
        {
            asteroidSpawnTime = Time.time;
            spawnAsteroids();
        }
    }

    void spawnEnemies()
    {
        while(enemiesSpawned < 10)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(enemyFighters, spawnPos, transform.rotation);
            enemiesSpawned++;
        }

        Debug.Log("Spawned Enemies");
        enemiesSpawned = 0;
    }

    void spawnAsteroids()
    {
        while(asteroidsSpawned < 30)
        {
            int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPosTwo = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(asteroidPrefabs[asteroidIndex], spawnPosTwo, Random.rotation);
            asteroidsSpawned++;
        }

        Debug.Log("Spawned Asteroids");
        asteroidsSpawned = 0;
    }
}
