using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{

    [SerializeField] private Transform Obstacle_Start;
    [SerializeField] private Transform Obstacle1;

    private void Awake()
    {
        Transform ObstaclePartTransform;
        ObstaclePartTransform = SpawnLevelPart(Obstacle_Start.Find("EndPosition").position);
        ObstaclePartTransform = SpawnLevelPart(ObstaclePartTransform.Find("EndPosition").position);
        ObstaclePartTransform = SpawnLevelPart(ObstaclePartTransform.Find("EndPosition").position);
        ObstaclePartTransform = SpawnLevelPart(ObstaclePartTransform.Find("EndPosition").position);
        ObstaclePartTransform = SpawnLevelPart(ObstaclePartTransform.Find("EndPosition").position);
        ObstaclePartTransform = SpawnLevelPart(ObstaclePartTransform.Find("EndPosition").position);


        // SpawnLevelPart(new Vector3(-2, 0) + new Vector3(15, 0));
        // SpawnLevelPart(new Vector3(-2, 0) + new Vector3(15, 0) + new Vector3(15,0));
        // Instantiate(Obstacle1, new Vector3(-2, 0), Quaternion.identity, gameObject.transform);
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition) {
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

