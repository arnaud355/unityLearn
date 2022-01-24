using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount = 0;
    public int waveEnemy = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveEnemy);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Renvoi le nombre d'objects tagués comme Enemy
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveEnemy++;
            SpawnEnemyWave(waveEnemy);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spwanPosX = Random.Range(-spawnRange, spawnRange);
        float spwanPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spwanPosX, 0, spwanPosZ);

        return randomPos;
    }
}
