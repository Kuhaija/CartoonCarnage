using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaussiMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool DudeIsDead = false;

    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;
    public GameObject MainChar;
    public GameObject MainCharViikate;
    public GameObject dead;
    public GameObject deadScythe;
    private int choice;
    

    void Start() {
        Time.timeScale = 1f;
        choice = MainMenu.choice;   
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
        dead.transform.position = MainChar.transform.position;
        dead.transform.rotation = MainChar.transform.rotation;
        deadScythe.transform.position = MainCharViikate.transform.position;
        deadScythe.transform.rotation = MainCharViikate.transform.rotation;
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
        ScoreScript.scoreValue = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Sie lopetit");
        ScoreScript.scoreValue = 0;
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("CartoonApocalypse");
        ScoreScript.scoreValue = 0;


    }
    public void Death()
    {
       dead.transform.localScale = MainChar.transform.localScale;
       deadScythe.transform.localScale = MainCharViikate.transform.localScale;
       deathMenuUI.SetActive(true);
       MainChar.SetActive(false);
       MainCharViikate.SetActive(false);
       Time.timeScale = 0f;
       GameIsPaused = true;
       ScoreScript.scoreValue = 0;
       if(choice == 1){
            dead.SetActive(true);
       }else if( choice == 2){
            deadScythe.SetActive(true);
       }
    }
}

