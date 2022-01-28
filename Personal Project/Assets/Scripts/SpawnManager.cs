using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUp;

    private float zEnemySpwan = 12.0f;
    private float xSpwanRange = 16.0f;
    private float zPowerUpRange = 5.0f;
    private float ySpwan = 0.75f;
    private float startDelay = 1.0f;
    private float enemySpwanTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpwanTime);
        InvokeRepeating("SpawnPowerUp", startDelay, enemySpwanTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpwanRange, xSpwanRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpwan, zEnemySpwan);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpwanRange, xSpwanRange);
        float randomZ = Random.Range(-zPowerUpRange, zPowerUpRange);

        Vector3 spawnPos = new Vector3(randomX, ySpwan, randomZ);

        Instantiate(powerUp, spawnPos, powerUp.gameObject.transform.rotation);
    }
}
