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
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        while (Input.GetMouseButtonDown(0) == false)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }

        if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space)) // kollar om det finns hopp kvar
        {
            body.velocity = new Vector2(body.velocity.x, jumpheight);
            jumpsLeft--;
        }
    }

    public void ResetJumpsLeft() => jumpsLeft = 2;
}