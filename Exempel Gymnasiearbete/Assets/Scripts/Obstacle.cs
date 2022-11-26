using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    public void SetColor(Color32 newcolor)
    {
        // Debug.Log(newcolor);
        tilemap.color = newcolor; 
    }
}
