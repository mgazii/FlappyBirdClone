using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object pooling class for obstacles
public class ObstaclePoolManager : MonoBehaviour
{
    private static ObstaclePoolManager manager;

    private ObstaclePoolManager() { }

    private void Awake()
    {
        manager = this;
    }

    public static ObstaclePoolManager Instance => manager;

    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private List<GameObject> obstaclePool;

    public int poolSize = 4;

    void Start()
    {
        obstaclePool = GenerateObstacles(poolSize);
    }
    
    private List<GameObject> GenerateObstacles(int amountOfObstacle)
    {
        for (int i = 0; i < amountOfObstacle; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, transform);
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }
        return obstaclePool;
    }

    public GameObject RequestObstacle()
    {
        foreach (var obstacle in obstaclePool)
        {
            if (obstacle.activeInHierarchy == false)
            {
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        GameObject newObstacle = Instantiate(obstaclePrefab, transform);
        obstaclePool.Add(newObstacle);

        return newObstacle;
    }
}
