using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlatforms : MonoBehaviour
{
    [SerializeField] private bool _vertical;
    [SerializeField] private bool _disappear;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] point;

    int i;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        if(_vertical == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, point[i].position, _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, point[i].position) < 0.1f)
            if (i > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && _disappear == true)
        {
            Destroy(gameObject, .1f);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(point[0].position, point[1].position);   
    }
}
