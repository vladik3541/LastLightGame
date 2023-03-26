using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool solar;
    [SerializeField] private bool leverOn;

    [SerializeField] private SolarL sl;
    [SerializeField] private bool destroySL;
    [SerializeField] private Lever lever;
    Rigidbody2D rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(solar == true)
        {
            if (sl.openDoor == true)
            {
                rb.gravityScale = -1f;
                if(destroySL)
                    Destroy(gameObject, 4f);
            }
            else
            {
                rb.gravityScale = 1f;
            }
        }
        if(leverOn == true)
        {
            if (lever.status == true)
            {
                rb.gravityScale = -1f;
                Destroy(gameObject, 4f);
            }
            
        }

    }
}
