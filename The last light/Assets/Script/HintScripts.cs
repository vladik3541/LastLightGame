using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintScripts : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textPlot;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.name == "Player")
        {
            textPlot.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            textPlot.GetComponent<TextMeshProUGUI>().enabled = false;
        }

    }
}
