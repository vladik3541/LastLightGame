using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnICI : MonoBehaviour
{
    [SerializeField] private GameObject Icicel;
    private bool i = true;

    private void Update() {
        if(i)
        {
            StartCoroutine("spawn", Random.Range(3,4));
        }
    }
    IEnumerator spawn(float t)
    {
        i = false;
        yield return new WaitForSeconds(t);
        Instantiate(Icicel, transform.position, transform.rotation);
        i = true;
    }
}
