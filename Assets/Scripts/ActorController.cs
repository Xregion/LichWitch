using UnityEngine;

public class ActorController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    float groundRadius = 0.05f;
    bool facingRight = true;
    bool grounded = false;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if (grounded && Input.GetButtonDown ("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
