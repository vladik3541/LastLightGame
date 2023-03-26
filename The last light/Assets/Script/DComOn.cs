using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DComOn : MonoBehaviour
{
    [SerializeField]private bool lighT;
    [SerializeField]private GameObject lampa;

    [SerializeField]private TextMeshProUGUI textPlot;

    private float globalTime;

    [SerializeField]private Animator _playerAnim;

    [SerializeField]private bool cinematic;

    [SerializeField]private GameObject buttom1;
    [SerializeField]private GameObject buttom2;

    void Update()
    {
        if(cinematic)
        {
            lampa.SetActive(false);
        }
        if(!cinematic)
        {
            if(lighT == true)
            {
                lampa.SetActive(true);
            }
            else
            {
                lampa.SetActive(false);
            }
            globalTime += Time.deltaTime;
            if(globalTime >= Random.Range(5,10f))
            {
                StartCoroutine("off", Random.Range(.05f, 1.1f));
                globalTime = 0;
            }
        }
    }

    IEnumerator off(float t)
    {
        lighT = false;
        yield return new WaitForSeconds(t);
        lighT = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.name == "Player")
        {
            if(!cinematic)
            {
                textPlot.GetComponent<TextMeshProUGUI>().enabled = true;
            }
            _playerAnim.SetBool("Coma", true);
            if(cinematic)
            {
                buttom1.SetActive(false);
                buttom2.SetActive(false);
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            if(!cinematic)
            {
                textPlot.GetComponent<TextMeshProUGUI>().enabled = false;
            }
            _playerAnim.SetBool("Coma", false);
            if(cinematic)
            {
                buttom1.SetActive(true);
                buttom2.SetActive(true);
            }
        }

    }

}
