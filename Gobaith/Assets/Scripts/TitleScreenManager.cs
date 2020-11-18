using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public string
        startGame,
        about,
        credits;

    public string[] levelList;
    public GameObject chapterList;

    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void ShowChapters()
    {
        if (chapterList.activeSelf == false)
            chapterList.SetActive(true);
        else
            chapterList.SetActive(false);
    }

    public void Chapter1(){
        SceneManager.LoadScene(levelList[0]);
    }

    public void Chapter2(){
        SceneManager.LoadScene(levelList[1]);
    }

    public void Quit()
    {
        Application.Quit();
    }


}