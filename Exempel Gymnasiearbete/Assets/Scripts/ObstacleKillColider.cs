using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleKillColider : MonoBehaviour
{

    //public int Respawn;
    public static event Action OnPlayerDeath;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.CompareTag("Player"))
        {


            //Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
            
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene(Respawn);
            //playerCollider.gameObject.transform.position = new Vector2(0,0);
        }
    }

}
