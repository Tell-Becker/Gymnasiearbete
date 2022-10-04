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
    private float timer = 0;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        //Detta leder till att man glidar efter man tryckt a eller d :/
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }
        // Detta ar inte en fungerande losning, nar man anvander hooken glider man fortfarnade och det ser inte bra ut nar man bara stannar
           if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * timer, body.velocity.y);
        }

        if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space)) // kollar om det finns hopp kvar
        {
            body.velocity = new Vector2(body.velocity.x, jumpheight);
            jumpsLeft--;
        }
    }

    public void ResetJumpsLeft() => jumpsLeft = 2;
}