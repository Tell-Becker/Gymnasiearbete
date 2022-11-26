using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    ParticleSystem jumpParticle;
    [SerializeField] PlayerMovement playerMovementScript;
    [SerializeField] JumpBoost jumpBoostScript;
    [SerializeField] GroundCheck groundCheckScript;

    // Update is called once per frame
    void Update()
    {
      
    if (jumpBoostScript.GetJumpBoosParticleEnabled() || playerMovementScript.jumpsLeft > 1)
    
    {
        Debug.Log(jumpParticle.particleCount);
        jumpParticle.Play();
        
        Debug.Log("Enable");
    }

    if (playerMovementScript.jumpsLeft == 0 || groundCheckScript.OnGround == true)
    {
        jumpBoostScript.DisableParticleEffect();
        // jumpParticle.Stop();
        Debug.Log("Disable");
    }  
    }
}
