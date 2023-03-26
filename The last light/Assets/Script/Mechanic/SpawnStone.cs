using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    [SerializeField] private GameObject Stone;

    [SerializeField] private int beginNumber = 8;
    [SerializeField] private int lastNumber = 10;

    private bool i = true;

    private void Update() 
    {
        if(i)
        {
            StartCoroutine("spawn", Random.Range(beginNumber,lastNumber));
        }
    }
    IEnumerator spawn(float t)
    {
        i = false;
        yield return new WaitForSeconds(t);
        Instantiate(Stone, transform.position, transform.rotation);
        i = true;

    }
}
