using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField]private GameObject nameGames;
    [SerializeField]private GameObject creditsText;

    public GameObject LoadingScren;
    public Slider scale;

    void Start()
    {
        StartCoroutine("NameGame", 9f);
    }
    IEnumerator NameGame(float t)
    {
        yield return new WaitForSeconds(t);
        nameGames.SetActive(true);
        StartCoroutine("credText", 5f);
    }
    IEnumerator credText(float t)
    {
        yield return new WaitForSeconds(t);
        nameGames.SetActive(false);
        creditsText.SetActive(true);
        StartCoroutine("exitInMenu", 10f);
    }
    IEnumerator exitInMenu(float t)
    {
        yield return new WaitForSeconds(t);
        LoadingScren.SetActive(true);
        StartCoroutine(LoadAsync());
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
