using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static bool count = false;
    public static int res;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            Counting();
        }
    }

    public void Counting()
    {
        res = 1000 * SceneManager.GetActiveScene().buildIndex - (10 * (10 * PlayerPrefs.GetInt("deadVal") + (int)LevelTimer.time * SceneManager.GetActiveScene().buildIndex));
        if (res < 0)
            res = 0;

        res += 100 * 0;
        Debug.Log(res);
        count = false;
        Debug.Log(count);
    }
}