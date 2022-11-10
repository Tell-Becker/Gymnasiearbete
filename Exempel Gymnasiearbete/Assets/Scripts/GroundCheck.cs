using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour

{
    public LayerMask layer;
    [SerializeField] private PlayerMovement movement;
    public bool OnGround;
    private LayerMask newLayer;


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
        newLayer = otherCollider.gameObject.layer;
        //Debug.Log(otherCollider.gameObject.layer);
        if (otherCollider.gameObject.layer == 6)
        {
            movement.ResetJumpsLeft();        
        }

    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == 6 && newLayer != 6)
        {
            movement.NotOnGround();
        }
    }
}
