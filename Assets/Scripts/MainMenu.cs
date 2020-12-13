using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject Map;
    public GameObject Open;
    public GameObject Closed;
    public GameObject BaseballBat;
    public GameObject Scythe;

    private bool isMuted;
    int highscoreNarc;
    public  static int choice;

	void Start ()
	{
		isMuted = PlayerPrefs.GetInt("MUTED") == 1;
		AudioListener.pause = isMuted;


	}
    void Update() 
    {
        /*if(choice !=1 && choice !=2)
        {
            Scythe.SetActive(true);
            BaseballBat.SetActive(true);
        }*/
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("You have quit the game");
        Application.Quit();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

	public void MutePressed()
	{
		isMuted = !isMuted;
		AudioListener.pause = isMuted;
		PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
	}

    public void ChooseMap()
    {
        Map.SetActive(true);
        highscoreNarc = PlayerPrefs.GetInt ("highscoreNarc", highscoreNarc);

        if(highscoreNarc < 10000){
            Closed.SetActive(true);
        }else if (highscoreNarc >= 10000) {
            Open.SetActive(true);
        }
    }

    public void Map1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Map2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void bat()
    {
        choice = 1;
        /*if(choice == 0){
            //Scythe.SetActive(false);
            choice = 1;
            Debug.Log(choice);
        }else if(choice == 1){
            //Scythe.SetActive(true);
            choice = 0;
        }*/
    }

    public void scythe()
    {
        choice = 2;
        /*if(choice == 0){
            //Scythe.SetActive(false);
            choice = 2;
            Debug.Log(choice);
        }else if(choice == 2){
            //Scythe.SetActive(true);
            choice = 0;
        }*/
    }
}

