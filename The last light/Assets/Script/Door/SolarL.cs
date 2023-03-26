using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarL : MonoBehaviour
{
    public bool solarUp = false;
    public bool openDoor = false;
    [SerializeField] private float AllTime;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioClip pressedSound;
    private AudioSource audioSource;

    private int i = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (solarUp == true)
        {
            animator.SetBool("SolarUp", true);
            AllTime += Time.deltaTime;
            if (AllTime > 6)
            {
                animator.SetBool("SolarUp", false);
                animator.SetBool("SolarLight", true);
                openDoor = true;
                if(i == 0)
                {
                    audioSource.pitch = Random.Range(0.78f, 0.9f);
                    audioSource.volume = Random.Range(0.3f, 0.5f);
                    audioSource.PlayOneShot(pressedSound);
                    i++;
                }
            }  
        }
        if (solarUp == false && AllTime > 6)
        {
            StartCoroutine("time", 3f);//time to open door
        }
        if (solarUp == false)
        {
            AllTime = 0;
            animator.SetBool("SolarUp", false);
            animator.SetBool("SolarDown", false);
        }

    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            solarUp = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            solarUp = false;
        }
    }
    IEnumerator time(float t)
    {   AllTime = 0;
        yield return new WaitForSeconds(t);
        animator.SetBool("SolarLight", false);
        animator.SetBool("SolarDown", true);
        openDoor = false;
    }
}
