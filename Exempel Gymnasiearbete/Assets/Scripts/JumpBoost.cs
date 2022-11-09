using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBoost : MonoBehaviour
{


    public static event Action JumpBoostActive;

    private void OnTriggerEnter2D(Collider2D Collider2D)
    {
        if (Collider2D.CompareTag("JumpBoost"))
        {
            Destroy(Collider2D.gameObject);
            JumpBoostActive?.Invoke();
        }
        // {
        //     // Debug.Log("Hej");
        //     JumpBoostActive?.Invoke();

        // }
    }
}
