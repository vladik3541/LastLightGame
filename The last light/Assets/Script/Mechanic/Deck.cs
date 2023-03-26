using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Animator animator;

    [SerializeField] private bool wrong;
    [SerializeField] private AudioClip wrongSound;

    private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            if(wrong == true)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                animator.SetTrigger("Wrong");
                wrong = false;
                audioSource.pitch = Random.Range(0.78f, 0.9f);
                audioSource.volume = Random.Range(0.4f, 0.4f);
                audioSource.PlayOneShot(wrongSound);
            }
        }
    }
    
}
