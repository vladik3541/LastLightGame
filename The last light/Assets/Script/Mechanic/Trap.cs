using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;
    private int i = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            if(i == 0)
            {
                audioSource.pitch = Random.Range(0.78f, 0.9f);
                audioSource.volume = Random.Range(0.3f, 0.4f);
                audioSource.PlayOneShot(pressedSound);
                i++;
            }
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
