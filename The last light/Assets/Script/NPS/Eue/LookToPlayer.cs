using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    [SerializeField]private bool flyUp = true;
    [SerializeField]private float speedFly;
    [SerializeField]private Transform player;
    [SerializeField]private Vector3 playerLastPos;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Fly();
        playerLastPos = player.transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg);
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
}
