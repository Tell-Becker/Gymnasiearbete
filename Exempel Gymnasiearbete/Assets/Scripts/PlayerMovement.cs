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
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void Update()
   {

        if (grapplerScript.isGrapplerActive == false) // fungerar men du har inget momentum
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
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

    public void ResetJumpsLeft() => jumpsLeft = 2;
}