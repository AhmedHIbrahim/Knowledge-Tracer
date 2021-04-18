using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public int spawnLength = 20;
    public int zSpawn = 0;
    public int numberOfInitialObstacles = 5;

    public Transform playerTransform;
    public GameObject[] obstacles;
    public List<GameObject> activeObstacles;



    void Start()
    {
        for (int i = 0; i < numberOfInitialObstacles; i++)
        {
            SpawnObstacles(Random.Range(0, obstacles.Length));
        }
    }
    void Update()
    {

        if (playerTransform.position.z - 10 > zSpawn - (spawnLength * numberOfInitialObstacles))
        {
            SpawnObstacles(Random.Range(0, obstacles.Length));
            DeleteObstacle();
        }
    }

    public void SpawnObstacles(int obstacleIndex)
    {

        GameObject obstacle = Instantiate(obstacles[obstacleIndex], transform.forward * zSpawn, transform.rotation);
        activeObstacles.Add(obstacle);
        zSpawn += spawnLength;

    }
    public void DeleteObstacle()
    {
        DestroyImmediate(activeObstacles[0], true);
        activeObstacles.RemoveAt(0);
    }
}
