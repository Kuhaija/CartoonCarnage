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

    private bool isMuted;
    int highscore;

	void Start ()
	{
		isMuted = PlayerPrefs.GetInt("MUTED") == 1;
		AudioListener.pause = isMuted;


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
        highscore = PlayerPrefs.GetInt ("highscore", highscore);
        //Debug.Log(highscore);
        if(highscore < 10000){
            Closed.SetActive(true);
        }else if (highscore >= 10000) {
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

    

}

