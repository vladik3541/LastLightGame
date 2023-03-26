using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Move playerEnter;
    public bool status = false;
    [SerializeField] private bool objectActive;
    [SerializeField] private GameObject platforms;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    private int i = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.name == "Player" && playerEnter.enter == true)
        {
            animator.SetBool("On", true);
            status = true;
            if(i == 0)
            {
                audioSource.pitch = Random.Range(0.78f, 0.9f);
                audioSource.volume = Random.Range(0.1f, 0.2f);
                audioSource.PlayOneShot(pressedSound);
                i++;
            }
            if(objectActive)
                platforms.SetActive(true);
        }
        
    }
}
