using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{

    [SerializeField] private Transform Obstacle1;

    void Start()
    {
    }

    
    private void Awake()
    {
        SpawnLevelPart(new Vector3(-2, 0));
        SpawnLevelPart(new Vector3(-2, 0) + new Vector3(15, 0));
        SpawnLevelPart(new Vector3(-2, 0) + new Vector3(15, 0) + new Vector3(15,0));
        // Instantiate(Obstacle1, new Vector3(-2, 0), Quaternion.identity, gameObject.transform);
    }

    private void SpawnLevelPart(Vector3 spawnPosition) {
        Instantiate(Obstacle1, spawnPosition, Quaternion.identity, gameObject.transform);
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
