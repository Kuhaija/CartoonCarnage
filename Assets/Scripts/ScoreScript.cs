using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField]
    public Text score;
    [SerializeField]
    private Text highScore;
    public static int highscoreNarc;
    public static int highscoreRainbow;
    
    // Start is called before the first frame update
    void Start()
    {
        highscoreNarc = PlayerPrefs.GetInt ("highscoreNarc", highscoreNarc);
        highscoreRainbow = PlayerPrefs.GetInt ("highscoreRainbow", highscoreRainbow);
        
    
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("CartoonApocalypse")){
        highScore.text = "HIGHSCORE: " + highscoreNarc;
            if (scoreValue > highscoreNarc){
                highscoreNarc = scoreValue;

                PlayerPrefs.SetInt ("highscoreNarc", highscoreNarc);
            }
        }
        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("LikeARainbowInAScene")){
        highScore.text = "HIGHSCORE: " + highscoreRainbow;
            if (scoreValue > highscoreRainbow){
                highscoreRainbow = scoreValue;

                PlayerPrefs.SetInt ("highscoreRainbow", highscoreRainbow);
            }
        }
        
    }
}
