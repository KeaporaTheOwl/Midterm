using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private GameObject enemyFighters;
    [SerializeField] private GameObject bossSummoner;
    private int initialEnemiesSpawned;
    private int initialAsteroidsSpawned;
    private int maxInitialEnemiesSpawned;
    private int maxInitialAsteroidsSpawned = 1000;
    private int enemiesSpawned;
    private int asteroidsSpawned;
    private int maxEnemiesSpawned;
    private int maxAsteroidsSpawned = 30;
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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "Level 1")
        {
            maxInitialEnemiesSpawned = 5;
            maxEnemiesSpawned = 3;
        }
        else if(sceneName == "Level 2")
        {
            maxInitialEnemiesSpawned = 10;
            maxEnemiesSpawned = 5;
        }

        while (initialEnemiesSpawned < maxInitialEnemiesSpawned)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-initialEnemySpawnRangeX, initialEnemySpawnRangeX), 0, Random.Range(-initialEnemySpawnRangeZ, initialEnemySpawnRangeZ));
            Instantiate(enemyFighters, spawnPos, transform.rotation);
            initialEnemiesSpawned++;
        }

        while (initialAsteroidsSpawned < maxInitialAsteroidsSpawned)
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
            SpawnEnemies();
        }

        if (Time.time > asteroidSpawnTime + asteroidSpawnDelay)
        {
            asteroidSpawnTime = Time.time;
            SpawnAsteroids();
        }
    }

    private void SpawnEnemies()
    {
        while (enemiesSpawned < maxEnemiesSpawned)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(enemyFighters, spawnPos, transform.rotation);
            enemiesSpawned++;
        }

        enemiesSpawned = 0;
    }

    private void SpawnAsteroids()
    {
        while (asteroidsSpawned < maxAsteroidsSpawned)
        {
            int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPosTwo = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(asteroidPrefabs[asteroidIndex], spawnPosTwo, Random.rotation);
            asteroidsSpawned++;
        }

        asteroidsSpawned = 0;
    }
}