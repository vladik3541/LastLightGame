using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;
    [SerializeField]private float movement;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    private bool isGrounded = false;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundRadius = 0.1f;
    [SerializeField]private LayerMask whatIsGround;
    [SerializeField]private LayerMask snowGround;
    [SerializeField]private bool timeBeginJump = false;
    [SerializeField]private float timeB = 0;
    private bool jumpSet;

    [SerializeField] private FloatingJoystick _joystick;
    
    public bool death = false;
    public bool enter = false;

    [SerializeField]
    private bool firstTime = true;
    private bool faceRight = true;
    private bool soundWalk = true;
    public bool noLight = true;
    [SerializeField]
    private GameObject lampa;

    [SerializeField]
    private AudioClip snowWalk;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (faceRight == false && movement > 0)
        {
            Flip();
        }
        else if (faceRight == true && movement < 0)
        {
            Flip();
        }
        beginJump();
    }
    void FixedUpdate()
    {   
        if (firstTime == true && death == false)
        {
            animator.SetBool("FirsTime", true);
            StartCoroutine("first", 4.0f);
        }
        if (firstTime == false && death == false)
        {
        if (noLight == false)
        {
            animator.SetBool("NoLight", false);
            lampa.SetActive(true);
        }
        if(enter == false)
        {
            Movet();
        }
        //animation Jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Jump", isGrounded);
        if(isGrounded)
        {
            animator.SetBool("Jump", false);
            speed = 2.1f;
        }
        else { 
            animator.SetBool("Jump", false);
            speed = 2.1f;
        }
        if (!isGrounded)
        {
            animator.SetBool("Jump", true);
            speed = 3.1f;
        }
            if (movement > 0 && soundWalk || movement < 0 && soundWalk)
            {
                if (isGrounded == true)
                {
                    audioSource.pitch = Random.Range(0.78f, 0.9f);
                    audioSource.volume = Random.Range(0.1f, 0.2f);
                    audioSource.PlayOneShot(snowWalk);
                    StartCoroutine("time", 0.5f);
                }
            }
        }
    }
    private void beginJump()
    {
        if(isGrounded)
        {
            timeB = 0;
            timeBeginJump = true;
            jumpSet = true;
        }
        if(!isGrounded)
        {
            timeB += Time.deltaTime;
            jumpSet = false;
            if(timeB > 1.0f)
            {
                timeBeginJump = false;
            }
        }
    }
    public void Movet()
    {
        movement = _joystick.Horizontal;
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        transform.position += new Vector3(_joystick.Direction.x, 0, 0) * speed * Time.deltaTime;  
        animator.SetFloat("Walk", Mathf.Abs(movement));
    }
    public void Enter()
    {
        if(isGrounded && death == false && noLight == false)
        {
            StartCoroutine("entert", 0.3f);
        }
    }
    public void Jump()
    {
        if (noLight == false && timeBeginJump && jumpSet && death == false)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);

    }
    IEnumerator time(float t)
    {
        soundWalk = false;
        yield return new WaitForSeconds(t);
        soundWalk = true;
    }
    IEnumerator first(float t)
    {
        yield return new WaitForSeconds(t);
        animator.SetBool("FirsTime", false); 
        firstTime = false;
    }
    IEnumerator entert(float t)
    {
        enter = true;
        animator.SetTrigger("Enter");
        yield return new WaitForSeconds(t);
        enter = false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "DeathObject")
        {
            death = true;
            animator.SetTrigger("DeathSpikes");
            sr.flipX = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.name.Equals("FlyPlatforms"))
        {
            this.transform.parent = col.transform;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("FlyPlatforms"))
        {
            this.transform.parent = null;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        
    }

}
