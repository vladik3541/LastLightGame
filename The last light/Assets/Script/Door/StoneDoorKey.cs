using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoorKey : MonoBehaviour
{
    [SerializeField] private Kol kol1, kol2,kol3;
    [SerializeField] private bool door1, door2, door3;
    Animator animator;

    Rigidbody2D rb;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    private int i = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {   
        if(door1 == true)
        {
            animator.SetTrigger("One");
            if(kol1.key == 2 && kol2.key == 1 && kol3.key == 3)
            {
                rb.gravityScale = -1f;
                if(i == 0)
                {
                    audioSource.pitch = Random.Range(0.78f, 0.9f);
                    audioSource.volume = Random.Range(0.3f, 0.5f);
                    audioSource.PlayOneShot(pressedSound);
                    i++;
                }
            }
        }
        if(door2 == true)
        {   
            animator.SetTrigger("Two");
            if(kol1.key == 1 && kol2.key == 2 && kol3.key == 3)
            {
                if(i == 0)
                {
                    audioSource.pitch = Random.Range(0.78f, 0.9f);
                    audioSource.volume = Random.Range(0.2f, 0.3f);
                    audioSource.PlayOneShot(pressedSound);
                    i++;
                }
                rb.gravityScale = -1f;
            }
        }
        if(door3 == true)
        {
            animator.SetTrigger("Three");
            if(kol1.key == 1 && kol2.key == 3 && kol3.key == 2)
            {
                rb.gravityScale = -1f;
                if(i == 0)
                {
                    audioSource.pitch = Random.Range(0.78f, 0.9f);
                    audioSource.volume = Random.Range(0.2f, 0.3f);
                    audioSource.PlayOneShot(pressedSound);
                    i++;
                }
            }
        }
    }
}
