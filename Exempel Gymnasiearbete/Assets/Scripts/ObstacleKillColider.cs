using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKillColider : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            // Destroy playerCollider
            playerCollider.gameObject.transform.position = new Vector2(0,0);
            // Destroy(playerCollider.gameObject);
        }
    }

}
