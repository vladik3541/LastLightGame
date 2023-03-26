using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float closedsec;
    [SerializeField] private float loadsec;
    [SerializeField] private float opensec;

    private float timeOpenPlatform;
    private float timeClosedPlatform;
    private float timeLoadPlatform;

    [SerializeField] private bool load = false;
    [SerializeField] private bool open = false;
    [SerializeField] private bool closed = true;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    private int i = 0;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(closed == true)
        {
            Sound();
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("Closed", true);
            timeClosedPlatform += Time.deltaTime;
            if(timeClosedPlatform > closedsec)
            {
                animator.SetBool("Closed", false);
                open = true;
                closed = false;
                timeClosedPlatform = 0;
                 i = 0;
            }
           
        }
        if(open == true)
        {   
            Sound();
            GetComponent<BoxCollider2D>().enabled = true;
            animator.SetBool("Open", true);
            timeOpenPlatform += Time.deltaTime;
            if(timeOpenPlatform > opensec)
            {
                animator.SetBool("Open", false);
                open = false;
                load = true;
                timeOpenPlatform = 0;
                i = 0;
            }
            
        }
        if(load == true)
        {
            
            animator.SetBool("Load", true);
            timeLoadPlatform += Time.deltaTime;
            if(timeLoadPlatform > loadsec)
            {
                animator.SetBool("Load", false);
                closed = true;
                load = false;
                timeLoadPlatform = 0;
            }
            
        }
    }
    void Sound()
    {
        if(i == 0)
            {
                audioSource.pitch = Random.Range(0.78f, 0.9f);
                audioSource.volume = Random.Range(0.3f, 0.4f);
                audioSource.PlayOneShot(pressedSound);
                i++;
            }
    }
}
