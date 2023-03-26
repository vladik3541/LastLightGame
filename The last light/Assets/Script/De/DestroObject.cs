using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroObject : MonoBehaviour
{
    [SerializeField]private float timeToDestroy;
    void Update()
    {
        Destroy(gameObject, timeToDestroy);
        
    }
    
}
