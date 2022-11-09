using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBoost : MonoBehaviour
{


    // public static event Action JumpBoostActive;
    [SerializeField] private PlayerMovement movement;

    private void OnTriggerEnter2D(Collider2D Collider2D)
    {
        if (Collider2D.CompareTag("JumpBoost"))
        {
            Destroy(Collider2D.gameObject);
            movement.JumpBoostenable();
        }
        // {
        //     // Debug.Log("Hej");
        //     JumpBoostActive?.Invoke();

        // }
    }
}
