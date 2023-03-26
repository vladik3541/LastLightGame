using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eue : MonoBehaviour
{
    [SerializeField] private GameObject _whiteLight;
    [SerializeField] private Animator _playerAnim;

    [SerializeField]private Transform attackPos;
    [SerializeField]private LayerMask enemy;
    [SerializeField]private float attackRange;

    [SerializeField]private float patrolSide;
    [SerializeField]private float speed;
    [SerializeField]private float speedFly;
    [SerializeField]private bool flyUp = true;
    [SerializeField]private bool rightM = true;

    [SerializeField]private bool faceRight = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        Fly();
        Walk();
        if (faceRight == false && !rightM)
        {
            Flip();
        }
        else if (faceRight == true && rightM)
        {
            Flip();
        }
        Collider2D[] enemis = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemis.Length; i++)
        {
            enemis[i].GetComponent<Move>().death = true;
            _playerAnim.SetTrigger("DeathEue");
            speed = 0;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        
    }
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, -180f, -90f);

    }
    void Walk()
    {
        if(rightM)
        {
            StartCoroutine("moveRight", patrolSide);
        }
        if(!rightM)
        {
            StartCoroutine("moveLeft", patrolSide);   
        }
    }
    void Fly()
    {
        if(flyUp)
        {
            StartCoroutine("numberUp", .5);
        }
        if(!flyUp)
        {
            StartCoroutine("numberDown", .5);   
        }
    }
    IEnumerator numberUp(float t)
    {   transform.position += new Vector3(0, 1, 0) * speedFly * Time.deltaTime;
        yield return new WaitForSeconds(t);
        flyUp = false;
    }
    IEnumerator numberDown(float t)
    {
        transform.position += new Vector3(0, -1, 0) * speedFly * Time.deltaTime;
        yield return new WaitForSeconds(t);
        flyUp = true; 
    }
    IEnumerator moveRight(float t)
    {   transform.position += new Vector3(1, 0 , 0) * speed * Time.deltaTime;
        yield return new WaitForSeconds(t);
        rightM = false;
    }
    IEnumerator moveLeft(float t)
    {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        yield return new WaitForSeconds(t);
        rightM = true; 
    }


}
