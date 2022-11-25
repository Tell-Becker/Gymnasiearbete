using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpBoost : MonoBehaviour
{
    private bool JumpBoostParticleEnabled;

    // public static event Action JumpBoostActive;
    [SerializeField] private PlayerMovement movement;

    private void OnTriggerEnter2D(Collider2D Collider2D)
    {
        if (Collider2D.CompareTag("JumpBoost"))
        {
            Destroy(Collider2D.gameObject);
            movement.JumpBoostenable();
            JumpBoostParticleEnabled = true;
        }
        // {
        //     // Debug.Log("Hej");
        //     JumpBoostActive?.Invoke();

        // }
    }
    
    public bool GetJumpBoosParticleEnabled() {return JumpBoostParticleEnabled;}

    public void DisableParticleEffect() => JumpBoostParticleEnabled = false;
}
