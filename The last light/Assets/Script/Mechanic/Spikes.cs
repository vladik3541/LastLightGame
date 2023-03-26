using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float upTime;
    [SerializeField] private float timeKill = 1;
    private bool kill;
    private Animator animator;
    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;

    private int i = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        upTime += Time.deltaTime;
        if(upTime > timeKill && kill == false)
        {
            StartCoroutine("killing",.4f);
        }

    }
    IEnumerator killing(float t)
    {
        GetComponent<BoxCollider2D>().enabled = true;
        upTime = 0;
        kill = true;
        animator.SetBool("SpikeUp", true);
        if(i == 0)
        {
            audioSource.pitch = Random.Range(0.78f, 0.9f);
            audioSource.volume = Random.Range(0.1f, 0.1f);
            audioSource.PlayOneShot(pressedSound);
            i++;
        }
        yield return new WaitForSeconds(t);
        GetComponent<BoxCollider2D>().enabled = false;
        kill = false;
        animator.SetBool("SpikeUp", false);
        i = 0;
    }
}
