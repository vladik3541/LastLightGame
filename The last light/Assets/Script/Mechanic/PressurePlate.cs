using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Animator anim;
    [Header ("Simulated Down")]
    [SerializeField] private bool simulatedObject;
    [SerializeField] private GameObject anyObjectForSimulated;
    
    [Header ("Door Open")]
    [SerializeField] private bool doorUp;
    [SerializeField] private Rigidbody2D rbDoor;
    [Header ("Active Object")]
    [SerializeField] private bool activeObject;
    [SerializeField] private GameObject setObject;
    
    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;

    private int i = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            anim.SetBool("Buttom", true);
            if(i == 0)
            {
                audioSource.pitch = Random.Range(0.78f, 0.9f);
                audioSource.volume = Random.Range(0.4f, 0.5f);
                audioSource.PlayOneShot(pressedSound);
                i++;
            }
            if(simulatedObject)
                anyObjectForSimulated.GetComponent<Rigidbody2D>().simulated = true;
                simulatedObject = false;
            if(doorUp)
                StartCoroutine("time", 4.0f);
            if(activeObject)
                setObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            audioSource.pitch = Random.Range(0.78f, 0.9f);
            audioSource.volume = Random.Range(0.3f, 0.4f);
            audioSource.PlayOneShot(pressedSound);
            anim.SetBool("Buttom", false);
            i = 0;
            
        }
    }
    IEnumerator time(float t)
    {
        rbDoor.gravityScale = -1;
        yield return new WaitForSeconds(t);
        rbDoor.gravityScale = 1;
    }
}
