using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour

{
    public LayerMask layer;
    [SerializeField] private PlayerMovement movement;
    public bool OnGround;
    private LayerMask newLayer;
    private Collider2D newOtherCollider;

    // private void OnCollisionEnter2D(Collider2D otherCollider)
    // {
    //     Debug.Log("Hello");
    //     if (otherCollider.gameObject.layer == 6)
    //     {
    //         movement.ResetJumpsLeft();
    //     }
    //     else
    //     {
    //         movement.NotOnGround();
    //     }
    // }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        OnGround = true;
        newLayer = otherCollider.gameObject.layer;
        newOtherCollider = otherCollider;
        //Debug.Log(otherCollider.gameObject.layer);
        if (otherCollider.gameObject.layer == 6)
        {
            movement.ResetJumpsLeft();        
        }
    }

    // private void OnTriggerEnter2D(Collider2D otherCollider)
    // {
        
    //     newLayer = otherCollider.gameObject.layer;
    //     newOtherCollider = otherCollider;
    //     //Debug.Log(otherCollider.gameObject.layer);
    //     if (otherCollider.gameObject.layer == 6)
    //     {
    //         movement.ResetJumpsLeft();        
    //     }

    // }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        OnGround = false;
        if ((otherCollider.gameObject.layer == 6 && newLayer != 6) || newOtherCollider == otherCollider)
        {
            movement.NotOnGround();
        }
    }
}
