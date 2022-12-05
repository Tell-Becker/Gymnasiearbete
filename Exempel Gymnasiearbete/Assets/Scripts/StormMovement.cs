using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormMovement : MonoBehaviour
{
    [SerializeField] private float stormStartSpeed;
    private Rigidbody2D stormBody;
    private float speedMultiplier = 0f;
    float timer = 1f;
    // [SerializeField] ScoreScript ScoreScript;
 
     private void Awake()
    {
        stormBody = GetComponent<Rigidbody2D>();
    }

    // !!!! Make it so that the storm starts moving if the player is moving 
    void Update()
    {
        stormBody.velocity = new Vector2(stormStartSpeed + speedMultiplier,0);

        // if (ScoreScript.newScore == 10)
        // {
        //     speedMultiplier += 10;
        // }
        // if (timer % Time.deltatime == 0)
        // stormStartSpeed = stormStartSpeed*speedMultiplier;
        
        // stormBody.velocity = new Vector2(Input.GetAxis("Horizontal") * stormStartSpeed, stormBody.velocity.y * Time.deltaTime);
    }
        
}

// body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);