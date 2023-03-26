using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Solar Lamp")]
    [SerializeField] private bool solar;
    [SerializeField] private SolarL sl;
    [Header("Lever")]
    [SerializeField] private bool leverOnOrOff;
    [SerializeField] private Lever lever;
    [SerializeField] private bool destroyDoor;
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
                if(destroyDoor)
                    Destroy(gameObject, 4f);
            }
            else
            {
                rb.gravityScale = 1f;
            }
        }
        if(leverOnOrOff == true)
        {
            if (lever.Status == true)
            {
                rb.gravityScale = -1f;
                Destroy(gameObject, 4f);
            }
            
        }

    }
}
