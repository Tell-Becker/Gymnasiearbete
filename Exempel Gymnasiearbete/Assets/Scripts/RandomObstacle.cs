using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomObstacle : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    [SerializeField] private Transform Obstacle_Start;
    [SerializeField] public List<Transform> ObstacleList;
    [SerializeField] private GameObject player;
    [SerializeField] public List<Transform> ObstacleChangeColorList;
    [SerializeField] private List<Color32> chosenObstacleColor = new List<Color32>();
    [SerializeField] private Color32 randomObstacleColor;
    bool Once = false;

    private Vector3 lastEndPosition;

    private void Start()
    {
        this.randomObstacleColor = chosenObstacleColor[Random.Range(0,chosenObstacleColor.Count)];
        lastEndPosition = Obstacle_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
        // Debug.Log(this.randomObstacleColor);
         ObstacleChangeColorList[0].GetChild(0).GetComponent<Tilemap>().color = randomObstacleColor;
    }

    private void Update() 
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            // Spawn another level part 
            SpawnLevelPart();
        }
        // int i = 0;
        // while (ObstacleChangeColorList.Count > i)
        // {
        //     ObstacleChangeColorList[i].GetChild(0).GetComponent<Tilemap>().color = randomObstacleColor;
        //     i++;
        //     // ObstacleChangeColorList[0].color = randomObstacleColor;
        // }
    }

    private void SpawnLevelPart()
    {
        Transform chosenObstacle = ObstacleList[Random.Range(0, ObstacleList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenObstacle, lastEndPosition);

        // ObstacleChangeColorList.Add(chosenObstacle);

        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        // Debug.Log(randomObstacleColor);

    }

    private Transform SpawnLevelPart(Transform obstacle, Vector3 spawnPosition) 
    {
        Transform ObstaclePartTransform  = Instantiate(obstacle, spawnPosition, Quaternion.identity, gameObject.transform);
        // Debug.Log(randomObstacleColor);
        ObstaclePartTransform.gameObject.GetComponent<Obstacle>().SetColor(this.randomObstacleColor);
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

