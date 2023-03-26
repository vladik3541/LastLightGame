using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransLang : MonoBehaviour
{
    [SerializeField] Language lang;
    [SerializeField] string englishText;
    [SerializeField] string ukraineText;

    [SerializeField]private TextMeshProUGUI text;


    void Update()
    {
        if(lang.english == false)
        {
            text.text = ukraineText;
        }
        if(lang.english == true)
        {
            text.text = englishText;
        }
    }
}
