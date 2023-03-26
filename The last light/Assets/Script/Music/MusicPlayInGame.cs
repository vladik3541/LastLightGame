using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayInGame : MonoBehaviour
{   
    [SerializeField]private GameObject mainSound;
    [SerializeField]private GameObject endSound;
    [SerializeField]private GameObject soundOne;
    [SerializeField]private GameObject soundTwo;

    [SerializeField]private bool finalScene;

    [SerializeField]private int numb;
    private float randomNumb;
    private float timer = 0;
    void Start()
    {
        numb = Random.Range(1,3);
        randomNumb = Random.Range(23f, 30f);
    }

    void Update()
    {   
        if(finalScene)
        {
            endSound.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            timer+=Time.deltaTime;
            if(numb == 1 && timer < randomNumb)
            {
                soundOne.GetComponent<AudioSource>().enabled = true;
            }
            if(numb == 2 && timer < randomNumb)
            {
                soundTwo.GetComponent<AudioSource>().enabled = true;
            }
            if (timer > randomNumb)
            {
                StartCoroutine("timeMusic", 82.22f);
            }
        }
    }

     IEnumerator timeMusic(float t)
     {
        if(numb == 1)
        {
            soundOne.GetComponent<AudioSource>().enabled = false;
        }
        if(numb == 2)
        {
            soundTwo.GetComponent<AudioSource>().enabled = false;
        }
        mainSound.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(t);
        timer = 0;
        mainSound.GetComponent<AudioSource>().enabled = false;
     }
}
