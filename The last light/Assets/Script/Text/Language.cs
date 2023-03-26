using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public bool english;
    private int boolLanguage = 0;

    private void Start()
    {
        boolLanguage = PlayerPrefs.GetInt("Language");
    }
    private void Update() 
    {
        if(boolLanguage == 1)
        {
            english = true;
        }
        if(boolLanguage == 0)
        {
            english = false;
        }
    }
    public void eng()
    {
        boolLanguage = 1;
        SaveLanguage();
    }
    public void ukr()
    {
        boolLanguage = 0;
        SaveLanguage();
    }
    
    void SaveLanguage()
    {
        PlayerPrefs.SetInt("Language", boolLanguage);
        PlayerPrefs.Save();
    }
    

}
