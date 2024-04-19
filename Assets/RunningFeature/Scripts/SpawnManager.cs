using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject waterPool;
    public GameObject deksadnarm;
    public float spawnRangeX = 1;
    public float spawnRangeZ = 10;
    public float spawnInterval = 2;

    void Start()
    {
        InvokeRepeating("SpawnRandomobstacle", spawnInterval, spawnInterval);
    }
    
    void SpawnRandomobstacle()
    {
        if (!GameManager.Instance.IsStarted())
            return;
        int r = Random.Range(0, 2);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        if (r == 0)
        {
            Instantiate(waterPool, spawnPos, waterPool.transform.rotation);
        }
        else if(r== 1) {
            int R = Random.Range(0, 2);
            spawnPos.x = R == 0 ? -spawnRangeX : spawnRangeX;
            spawnPos.y = 0.5f;
            GameObject a = Instantiate(deksadnarm, spawnPos, deksadnarm.transform.rotation);
            a.transform.localScale = new Vector3(R == 0 ? 1 : -1, 1, 1);
        }
    }
}
