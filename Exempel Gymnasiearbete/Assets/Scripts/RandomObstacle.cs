using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    [SerializeField] private Transform Obstacle_Start;
    [SerializeField] private Transform Obstacle1;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = Obstacle_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update() 
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            // Spawn another level part 
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

    }

    private Transform SpawnLevelPart(Vector3 spawnPosition) 
    {
        Transform ObstaclePartTransform  = Instantiate(Obstacle1, spawnPosition, Quaternion.identity, gameObject.transform);
        return ObstaclePartTransform;
    }
    
    // private void Start () 
    // {
    //     SpawnObstacle();
    // 

    // [SerializeField] GameObject[] obstacles;

    // private void SpawnObstacle()
    // {
    //     //spawnPoint = grid.length;
    //     Instantiate(obstacles[Random.Range(0,obstacles.Length - 1)], spawnPoint.position, Quaternion.identity, transform);
    // }

}

