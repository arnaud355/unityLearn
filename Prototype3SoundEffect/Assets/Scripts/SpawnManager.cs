using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float start = 2.0f;
    private float repeatRate = 3.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", start, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, obstaclesPrefab.Length);           
            Instantiate(obstaclesPrefab[index], spawnPos, obstaclesPrefab[index].transform.rotation);
            if (index == 0)
            {
                playerControllerScript.speedUpPlayer = true;
            }
            else
            {
                playerControllerScript.speedUpPlayer = false;
            }
        }
            
    }
}
