using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNip : MonoBehaviour
{
    private float time;
    private bool timeGo = false;
    private bool moveRigth = true;
    [SerializeField] private float rayDistans;
    [SerializeField] private float speed;
    [SerializeField]private bool Cinematic;
    [SerializeField] private TriggerDeath triggerDeath;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Update()
    {   if(Cinematic)
        {
            speed = 0;
            animator.SetBool("Walk", false);
            
        }
        if(!Cinematic)
        {
            if (timeGo == true)
            {
                speed = 0;
                animator.SetBool("Walk", false);
                time += Time.deltaTime;
                if (time > 1.5f)
                {
                    triggerDeath.DeathNip();
                    Destroy(gameObject, .1f);
                }
            }
            if (timeGo == false)
            {
                time = 0;
                Move();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            timeGo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            timeGo = false;
        }
    }
    void Move()
    {
        if (moveRigth)
        {
            speed = 3;
            animator.SetBool("Walk", true);
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.right, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {
                transform.Rotate(0, 180, 0);
                moveRigth = false;
            }
        }
        if (!moveRigth)
        {
            speed = 3;
            animator.SetBool("Walk", true);
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.left, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {
                transform.Rotate(0, -180, 0);
                moveRigth = true;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistans);
    }

}
