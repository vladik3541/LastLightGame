using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObct : MonoBehaviour
{
    [SerializeField]private Move player;
    [SerializeField]private Animator playerAnim;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.death = true;
            playerAnim.SetTrigger("DeathSpikes");
        }
    }
}
