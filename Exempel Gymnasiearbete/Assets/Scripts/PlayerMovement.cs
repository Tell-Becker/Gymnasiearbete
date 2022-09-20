using UnityEngine;

 
public class PlayerMovement : MonoBehaviour
{ 

    void start()
    {
        
    }


    [SerializeField] private float speed;
    [SerializeField] private float raycastDownDistance = 0.01f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform leftPoint;
    private int jumpsLeft = 2;
    private Rigidbody2D body;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        RaycastHit2D hitLeft = Physics2D.Raycast(leftPoint.position, Vector2.down, raycastDownDistance, whatIsGround);
        RaycastHit2D hitRight = Physics2D.Raycast(rightPoint.position, Vector2.down, raycastDownDistance, whatIsGround);
        if (hitRight.collider != null || hitLeft.collider != null) // ockso om nogra av raycast har traffat marken.
        {
            if (jumpsLeft > 0 && Input.GetKey(KeyCode.Space)) // kollar om det finns hopp kvar
            {
                body.velocity = new Vector2(body.velocity.x, speed);
                jumpsLeft--;
            }

            // if (hitRight.collider == null && hitLeft.collider == null)
            // {
            //     if (jumpsLeft == 1)
            //     {
            //         if (Input.GetKey(KeyCode.Space)) // kollar om det finns hopp kvar
            //         {
            //             body.velocity = new Vector2(body.velocity.x, speed);
            //             jumpsLeft--;
            //         }
            //     }
            // }

            else
            {
                jumpsLeft = 2;
            }
            
            
        }

            
    }
}