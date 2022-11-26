using UnityEngine;

 
public class PlayerMovement : MonoBehaviour
{ 

    ParticleSystem jumpParticle;
    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;
    [SerializeField] private float raycastDownDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform bottomPoint;
    public int jumpsLeft;
    private Rigidbody2D body;
    public grappler grapplerScript;
    [SerializeField] JumpBoost jumpBoostScript;
    [SerializeField] GroundCheck groundCheckScript;
    private bool hasGrappled = false;
    private float grappleReleaseSpeed;
    [SerializeField] float maximumGrapplingSpeed;
    [SerializeField] float grapplingSpeedRetardation = 0.1f;

    private void OnEnable()
    {
        ObstacleKillCollider.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        ObstacleKillCollider.OnPlayerDeath -= DisablePlayerMovement;
    } 


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>(); 
        jumpParticle = GetComponent<ParticleSystem>();
        EnablePlayerMovement();
    }

    // private void start()
    // {
    //     jumpParticle = GetComponent<ParticleSystem>();
    //     EnablePlayerMovement();
    // }

    private void Update()
   {
    // Debug.Log(jumpParticle.isPlaying);
    // Debug.Log(jumpBoostScript.GetJumpBoosParticleEnabled());
    

    // if (jumpBoostScript.GetJumpBoosParticleEnabled() || jumpsLeft > 1)
    
    // {
    //     // Debug.Log(jumpParticle.particleCount);
    //     jumpParticle.Play();
        
    //     Debug.Log("Enable");
    // }

    // if (jumpsLeft == 0 || groundCheckScript.OnGround == true)
    // {
    //     jumpBoostScript.DisableParticleEffect();
    //     // jumpParticle.Stop();
    //     Debug.Log("Disable");
    // }

    speed = 8;

        if (grapplerScript.isGrapplerActive == true && !hasGrappled)
        {   
            hasGrappled = true;
        }
        if (hasGrappled == false &&  body.bodyType != RigidbodyType2D.Static) // fungerar men du har inget momentum
        {

            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }

        else if (grapplerScript.isGrapplerActive == false && hasGrappled && grappleReleaseSpeed != 0)
        {

            //Debug.Log(grappleReleaseSpeed);

        
            if (grappleReleaseSpeed > 8)
            {
                grappleReleaseSpeed = 8;
            }

            else if (grappleReleaseSpeed < -8)
            {
                grappleReleaseSpeed = -8;
            }

            else if (grappleReleaseSpeed <= 8 && grappleReleaseSpeed > 0 )
            {
                if (grappleReleaseSpeed > 0.02f)
                {
                    grappleReleaseSpeed -= grapplingSpeedRetardation * 1;
                    grappleReleaseSpeed += 0.06f; 
                }

                if (Input.GetKey(KeyCode.A)) 
                {
                    speed = 8;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    speed = 8 - grappleReleaseSpeed;
                }
                if (body.bodyType != RigidbodyType2D.Static)
                {
                    body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
                }

            }

            else if (grappleReleaseSpeed >= -8 && grappleReleaseSpeed < 0)
            {
                if (grappleReleaseSpeed < -0.02f)
                {
                    grappleReleaseSpeed += grapplingSpeedRetardation * 1;
                    grappleReleaseSpeed -= 0.06f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    speed = 8 + grappleReleaseSpeed;
                    //grappleReleaseSpeed = grappleReleaseSpeed - speed;    
                }
                if (Input.GetKey(KeyCode.D))
                {
                    speed = 8;
                }
                if (body.bodyType != RigidbodyType2D.Static)
                {
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
                }
            }

            else if (grappleReleaseSpeed == 0)
            {
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            }        
        }



        if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space)) // kollar om det finns hopp kvar
        {
            body.velocity = new Vector2(body.velocity.x, jumpheight);
            jumpsLeft--;
        
        }
            


        
    }

    public void JumpBoostenable()
    {
        jumpsLeft += 1;
        // JumpBoost.JumpBoostActive += addJumpsLeft;
    }

    public void addJumpsLeft()
    {
        jumpsLeft += 1;
    }

    public void ResetJumpsLeft()  
    {
        // if (jumpParticle.isPlaying)
        // {
        //     jumpParticle.Stop();
        // }
        hasGrappled = false;
        jumpsLeft = 1;
        // jumpBoostScript.DisableParticleEffect();
        
        // Debug.Log(jumpsLeft);
    } 

    public void NotOnGround()
    {
        jumpsLeft = 0;
        
        // Debug.Log(jumpsLeft);
    }

    public void ReleasedGrapple() => grappleReleaseSpeed = body.velocity.x;

    private void DisablePlayerMovement()
    {
        // animator.enabled = false;
        body.bodyType = RigidbodyType2D.Static;
    }

        private void EnablePlayerMovement()
    {
        // animator.enabled = true;
        body.bodyType = RigidbodyType2D.Dynamic;
    }

}