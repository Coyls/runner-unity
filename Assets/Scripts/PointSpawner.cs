using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject pointPrefabs;
    [Header("Timers")]
    [SerializeField] float timeToSpawn = 2f;
    [SerializeField] float timeBetweenWaves = 1f;

    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnObstacle();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int spawn = 0; spawn < spawnPoints.Length; spawn++)
        {
            if (spawn != randomIndex)
            {
                Instantiate(pointPrefabs.transform, spawnPoints[spawn].position, Quaternion.identity);
            }
        }
    }
}
