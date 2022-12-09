using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float obstacleTimer = 3;
    private float[] spawnPos;
    public GameObject obstacle;

    private void Start()
    {
        spawnPos = new[] { -3.5f, 3.5f };
        StartCoroutine(ObstacleSpawnerCoroutine());
    }

    private void Update()
    {
        obstacleTimer = 3 - (GameSpeed.Instance.GetGameSpeed() / 5);
    }

    private IEnumerator ObstacleSpawnerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleTimer);
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(Random.Range(spawnPos[0], spawnPos[1]), 6, 0), Quaternion.identity);
    }
}
