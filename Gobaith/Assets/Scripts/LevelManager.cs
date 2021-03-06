﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string restartLevel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(restartLevel);
            FruitFollow.trig = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelTimer.time = 0;
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
