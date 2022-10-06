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
            body.velocity = new Vector2(Mathf.Clamp((Input.GetAxis("Horizontal") * speed + grappleReleaseSpeed), -(maximumGrapplingSpeed + grappleReleaseSpeed), maximumGrapplingSpeed + grappleReleaseSpeed), body.velocity.y);
        }


        // if (grapplerScript.isGrapplerActive == true && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        // {
        //     body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        // }

        //Need to add something that makes grappling not lose momentum

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