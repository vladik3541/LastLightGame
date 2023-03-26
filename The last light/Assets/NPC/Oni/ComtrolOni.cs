using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrolOni : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField]private float scared;

    [SerializeField] float rayDistans;

    private bool ligthdamage = false;
    private Animator animator;
    
    private bool moveRigth = true;

    [SerializeField] private GameObject player;

    private bool isGrounded = false;
    [SerializeField]private Transform groundCheck;
    private float groundRadius = 0.3f;
    [SerializeField]private LayerMask whatIsGround;

    SpriteRenderer sr;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        scared += Time.deltaTime;
        if (scared >= 2)
        { 
            ligthdamage = false;
            scared = 0; 
        }
        if (ligthdamage)
        {
            if (player.transform.position.x < transform.position.x)
            {
                moveRigth = true;
                
            }

            if (player.transform.position.x > transform.position.x)
            {
                moveRigth = false;
            }
            
        }
        Move();
        Down();
        
    }
    void Move()
    {
        if (moveRigth)
        {
            sr.flipX = false;
            animator.SetBool("Walk", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.right, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {
                
                moveRigth = false;
            }
        }
        if (!moveRigth)
        {
            sr.flipX = true;
            animator.SetBool("Walk", true);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.left, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {

                moveRigth = true;
            }
        }
    }
    void Down()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Down", isGrounded);
        if(!isGrounded)
        {
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistans);
    }
}
