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

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void Update()
   {

        if (grapplerScript.isGrapplerActive == true && !hasGrappled)
        {            
            hasGrappled = true;
        }

        if (hasGrappled == false) // fungerar men du har inget momentum
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }
        else if (grapplerScript.isGrapplerActive == false && hasGrappled)
        {
            
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);

            //body.velocity = new Vector2(Mathf.Clamp((Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed), -(speed - grappleReleaseSpeed), speed + grappleReleaseSpeed), body.velocity.y);

            //Farsaker gara att hastigheten + releasedgrapplespeed aldrig averstiger 8

            // if (grappleReleaseSpeed > 8)
            // {
            //     grappleReleaseSpeed = 8;
            //     if (Input.GetKey(KeyCode.A)) 
            //     {
            //         speed = 8;
            //         body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
            //     }
            //     if (Input.GetKey(KeyCode.A))
            //     {
            //         speed = 2;
            //         body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
            //     }
            // }
            // else if (grappleReleaseSpeed < -10)
            // {
            //     grappleReleaseSpeed = -8;
            //     if (Input.GetKey(KeyCode.A)) 
            //     {
            //         speed = 2;
            //         body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
            //     }
            //     if (Input.GetKey(KeyCode.A))
            //     {
            //         speed = 8;
            //         body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed, body.velocity.y);
            //     }
            // }
        
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
        jumpsLeft = 2;
    } 

    public void ReleasedGrapple() => grappleReleaseSpeed = body.velocity.x;

}