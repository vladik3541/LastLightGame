using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField]private float rayDistans;

    private bool moveRigth = true;
    [SerializeField]private WheelJoint2D wheel;
    [SerializeField]private JointMotor2D motor;

    private AudioSource audioSource;

    private void Start()
    {
        wheel = GetComponent<WheelJoint2D>();
        motor = wheel.motor;
        Physics2D.queriesStartInColliders = false;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        wheel.motor = motor;
        if(moveRigth == true)
        {
            motor.motorSpeed = 1000;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.left, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {
                StartCoroutine("mRight", 2f);
            }
        }
        if(moveRigth == false)
        {   
            motor.motorSpeed = -1000;
            int layerMask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector3.right, rayDistans, layerMask, 0);
            if (hit.collider != null)
            {
                StartCoroutine("lRight", 2f);
            }  
        } 
    }
    IEnumerator mRight(float t)
    {
        motor.motorSpeed = 0;
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(t);
        moveRigth = false;
        GetComponent<AudioSource>().enabled = true;
    }
    IEnumerator lRight(float t)
    {
        motor.motorSpeed = 0;
        GetComponent<AudioSource>().enabled = false;
        yield return new WaitForSeconds(t);
        moveRigth = true;
        GetComponent<AudioSource>().enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistans);
    }
}
