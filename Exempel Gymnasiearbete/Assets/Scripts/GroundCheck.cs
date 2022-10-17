using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour

{
    public LayerMask layer;
    [SerializeField] private PlayerMovement movement;
    public bool OnGround;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
        //Debug.Log(otherCollider.gameObject.layer);
        if (otherCollider.gameObject.layer == 6)
        {
            movement.ResetJumpsLeft();        
        }
        else 
        {
            //OnGround = false;
        }

    
        // kolla om den andra collidern är ground. 
        // I så fall tillkalla resetjumpsleft() i player.
    }
    // private void Update()
    // {
    //     if (OnGround == false);
    //     {
    //         movement.NotOnGround();
    //     }
    // }
}
