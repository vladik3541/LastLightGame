using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private float jumpHeight;
    private bool isGrounded = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;

    private bool faceRight = true;

    Rigidbody2D rb;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        FindGround();
        //MaxSpeed();
    }

    private void FindGround() => IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    public void MoveLogic() {
        rb.velocity = new Vector2((float)Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (faceRight == false && Input.GetAxis("Horizontal") > 0)
        {
            Flip();
        }
        else if (faceRight == true && Input.GetAxis("Horizontal") < 0)
        {
            Flip();
        }
    }
    public void JumpLogic() {
        if(IsGrounded && Mathf.Abs(rb.velocity.y) < 0.05)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
    private void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        
    }
    
}
