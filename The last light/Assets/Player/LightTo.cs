using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTo : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemis = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemis.Length; i++)
        {
            enemis[i].GetComponent<ComtrolOni>().ligthdamage = true;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        
    }
}
