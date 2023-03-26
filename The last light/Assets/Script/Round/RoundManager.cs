using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private bool inMenu;
    [SerializeField] private CharacterPlayer player;
    public string number;
    [SerializeField] private string numberNextScene;

    [SerializeField]private Slider scale;
    [SerializeField]private GameObject LoadingScren;

    private int nextScen = 0;

    void Update()
    {
        if(!inMenu)
        {
            if(player.Death == true)
            {
                StartCoroutine("restart", 3f);
            }
            PlayerPrefs.SetString("ThisRound", number);
            PlayerPrefs.Save();
        }
    }
    public void NewGame()
    {
        LoadingScren.SetActive(true);
        StartCoroutine(NewGameLoadAsync());
        //PlayerPrefs.DeleteKey("ThisRound");
    }
    public void Continue()
    {
        if(PlayerPrefs.HasKey("ThisRound"))
        {
            LoadingScren.SetActive(true);
            number = PlayerPrefs.GetString("ThisRound");
            StartCoroutine(ContLoadAsync());
        }
    }
    IEnumerator restart(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Round" + number);
    }
    IEnumerator NewGameLoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Round1");
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
    IEnumerator ContLoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Round" + number);
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

    void OnTriggerEnter2D(Collider2D col)//NextRoundStep
    {
        if(col.name == "Player")
        {
            nextScen += 1;
            if(nextScen == 1)
            {
                LoadingScren.SetActive(true);
                StartCoroutine(NextLoadAsync());
            }
        }
    }
    IEnumerator NextLoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Round" + numberNextScene);
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
