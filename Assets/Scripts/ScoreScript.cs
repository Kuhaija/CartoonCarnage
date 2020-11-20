using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField]
    public Text score;
    [SerializeField]
    private Text highScore;
    public static int highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        //score = GetComponent<Text> ();
        //highScore = GetComponent<Text> ();
        highscore = PlayerPrefs.GetInt ("highscore", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        //SAMA TEKSTI TULEE MOLEMPII .texteihin!!
        highScore.text = "HIGHSCORE: " + highscore;
        if (scoreValue > highscore){
            highscore = scoreValue;

            PlayerPrefs.SetInt ("highscore", highscore);
        }
        
    }
}
