using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRangeX = 2;
    public float spawnRangeZ = 10;
    public float spawnInterval = 2;

    void Start()
    {
        InvokeRepeating("SpawnRandomobstacle", spawnInterval, spawnInterval);
    }
    
    void SpawnRandomobstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0,spawnRangeZ);
         int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
         Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
