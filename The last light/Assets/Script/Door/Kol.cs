using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kol : MonoBehaviour
{
    public int key = 1;
    Animator animator;

    private bool allReady = true;

    [SerializeField] private Move playerEnter;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.name == "Player" && Input.GetButton("E") && allReady == true)
        {
            StartCoroutine("number", 1f);
            key += 1;
            animator.SetInteger("Key", key);
            if(key > 3)
            {
                key = 1;
            }
        }
    }
    IEnumerator number(float t)
    {
        allReady = false;
        audioSource.pitch = Random.Range(0.78f, 0.9f);
        audioSource.volume = Random.Range(0.3f, 0.4f);
        audioSource.PlayOneShot(pressedSound);
        yield return new WaitForSeconds(t);
        allReady = true;
        
    }
}
