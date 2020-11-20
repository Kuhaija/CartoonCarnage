using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaussiMenuRainbow : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool DudeIsDead = false;

    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;
    

    void Start() {
        Time.timeScale = 1f;   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("Sie lopetit");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("LikeARainbowInAScene");
        ScoreScript.scoreValue = 0;


    }
    public void Death()
    {
       deathMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    }
}

