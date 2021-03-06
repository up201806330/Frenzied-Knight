﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private Score score;

    public bool lost = false;
    private bool once = true;

    private AudioSource pauseSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        score = GetComponent<Score>();

        pauseSound = GameObject.Find("PauseSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //pausing and resuming game
        if(!lost)
        {
            if(Input.GetButtonDown("Pause") && Time.timeScale == 1)
             Pause();
             else if(Input.GetButtonDown("Pause"))
                 Resume();
        }

        else
        {
            score.UpdateHighScore(); //We save the high score before game over, otherwise retrying would erase the high score
            GameOver();
        }
    }

    
    public void Pause()
    {
        pauseSound.Play();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseSound.Play();
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if(once)
        {
            //deadSound.Play();
            once = false;
        }

        lost = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        //resetting highscore to 0
        score.ResetHighScore();
        //going back to main menu
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}