using UnityEngine;

 
public class PlayerMovement : MonoBehaviour
{ 

    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;
    [SerializeField] private float raycastDownDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform bottomPoint;
    private int jumpsLeft;
    private Rigidbody2D body;
    public grappler grapplerScript;
    public GroundCheck groundChecker;
    
    private bool hasGrappled = false;
    private float grappleReleaseSpeed;
    [SerializeField] float maximumGrapplingSpeed;
    [SerializeField] float grapplingSpeedRetardation = 0.1f;

    Animator animator;

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
        animator = GetComponent<Animator>(); 
    }

    private void start()
    {
        EnablePlayerMovement();
    }

    private void Update()
   {

    speed = 8;
        if (grapplerScript.isGrapplerActive == true && !hasGrappled)
        {            
            hasGrappled = true;
        }

        if (hasGrappled == false) // fungerar men du har inget momentum
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
                    grappleReleaseSpeed -= grapplingSpeedRetardation;
                    grappleReleaseSpeed += 0.085f;
                }

                if (Input.GetKey(KeyCode.A)) 
                {
                    speed = 8;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    speed = 8 - grappleReleaseSpeed;
                }
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);

            }

            else if (grappleReleaseSpeed >= -8 && grappleReleaseSpeed < 0)
            {
                if (grappleReleaseSpeed < -0.02f)
                {
                    grappleReleaseSpeed += grapplingSpeedRetardation;
                    grappleReleaseSpeed -= 0.085f;
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
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);

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

    public void ResetJumpsLeft() 
    {
        hasGrappled = false;
        jumpsLeft = 1;
    } 

    public void ReleasedGrapple() => grappleReleaseSpeed = body.velocity.x;

    private void DisablePlayerMovement()
    {
        animator.enabled = false;
        body.bodyType = RigidbodyType2D.Static;
    }

        private void EnablePlayerMovement()
    {
        animator.enabled = true;
        body.bodyType = RigidbodyType2D.Dynamic;
    }

}