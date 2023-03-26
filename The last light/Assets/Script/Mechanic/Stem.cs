using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stem : MonoBehaviour
{
    [SerializeField]private Move player;
    [SerializeField]private Animator animPlayer;

    [SerializeField]private float wait;
    [SerializeField]private float flyUp;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    private int i = 0;

    private float seconds = 0; 

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds > wait)
        {
            
            StartCoroutine("timeUp", flyUp);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            player.death = true;
            animPlayer.SetTrigger("DeathSpikes");
        }
    }
    IEnumerator timeUp(float t)
    {
        if(i == 0)
        {
            audioSource.pitch = Random.Range(0.78f, 0.9f);
            audioSource.volume = Random.Range(0.4f, 0.5f);
            audioSource.PlayOneShot(pressedSound);
            i++;
        }
        rb.gravityScale = -1;
        yield return new WaitForSeconds(t);
        rb.gravityScale = 1;
        seconds = 0;
        i = 0;
    }
}
