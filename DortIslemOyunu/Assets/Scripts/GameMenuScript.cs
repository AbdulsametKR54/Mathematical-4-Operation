using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class GameMenuScript : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    public GameObject menuButon, playButon, pauseButon;
    // Start is called before the first frame update
    void Start()
    {
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void pauseButton()
    {
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void playButton()
    {
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void menuButton()
    {
        if (GameScripts.controller != 0)
        {
            DataManager.Instance.SaveData();
        }
        SceneManager.LoadScene(0);
    }
}
