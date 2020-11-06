using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private bool isMuted;

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

    

}

