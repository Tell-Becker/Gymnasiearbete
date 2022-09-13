using UnityEngine;

 
public class PlayerMovement : MonoBehaviour
{ 

    void start()
    {
        
    }


    [SerializeField] private float speed;
    [SerializeField] private float raycastDownDistance = 0.4f;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D body;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
 
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDownDistance, whatIsGround);
            if (hit.collider != null) 
            {
                body.velocity = new Vector2(body.velocity.x, speed);
            }
            
        }
            
    }
}