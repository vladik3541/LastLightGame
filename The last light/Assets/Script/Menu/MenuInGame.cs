using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private GameObject jump;
    [SerializeField]private GameObject enter;
    [SerializeField]private GameObject esc;
    [SerializeField]private GameObject buttonMenu;
    [SerializeField]private GameObject playerLamp;

    public GameObject LoadingScren;
    public Slider scale;

    [SerializeField]private string number;

    [SerializeField] private bool _mobileImport;
    private void Update()
    {
        Esc();
    }
    public void Esc()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            buttonMenu.SetActive(true);
        }
        if(_mobileImport)
        {
            Time.timeScale = 0;
            enter.SetActive(false);
            esc.SetActive(false);
            _joystick.GetComponent<FloatingJoystick>().enabled = false;
            jump.SetActive(false);
            buttonMenu.SetActive(true);
            playerLamp.SetActive(false);
        }
        
    }
    public void Continue()
    {
        Time.timeScale = 1;
        enter.SetActive(true);
        esc.SetActive(true);
        _joystick.GetComponent<FloatingJoystick>().enabled = true;
        jump.SetActive(true);
        buttonMenu.SetActive(false);
        playerLamp.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Round" + number);
        Time.timeScale = 1;
    }
    public void ExitMain()
    {
        LoadingScren.SetActive(true);
        playerLamp.SetActive(false);
        StartCoroutine(LoadAsync());
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Menu");
        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;
            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(3.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
