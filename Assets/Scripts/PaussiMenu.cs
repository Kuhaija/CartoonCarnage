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
    public GameObject död;
    public GameObject dödScythe;
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
        död.transform.position = MainChar.transform.position;
        död.transform.rotation = MainChar.transform.rotation;
        dödScythe.transform.position = MainCharViikate.transform.position;
        dödScythe.transform.rotation = MainCharViikate.transform.rotation;
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
       död.transform.localScale = MainChar.transform.localScale;
       dödScythe.transform.localScale = MainCharViikate.transform.localScale;
       deathMenuUI.SetActive(true);
       MainChar.SetActive(false);
       MainCharViikate.SetActive(false);
       Time.timeScale = 0f;
       GameIsPaused = true;
       ScoreScript.scoreValue = 0;
       if(choice == 1){
            död.SetActive(true);
       }else if( choice == 2){
            dödScythe.SetActive(true);
       }
    }
}

