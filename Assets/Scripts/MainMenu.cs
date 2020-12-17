using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject Map;
    public GameObject Open;
    public GameObject Closed;
    public GameObject BaseballBat;
    public GameObject Scythe;
    public GameObject ScytheNO;
    public GameObject ScytheBuy;
    public GameObject Weapons;

    public int RageGainBat;
    public GameObject RageGainBat1;
    public GameObject RageGainBat2;
    public GameObject RageGainBat3;
    public GameObject RageGainBat1Taken;
    public GameObject RageGainBat2Taken;
    public GameObject RageGainBat3Taken;

    public int AttackSpeedBat;
    public GameObject AttackSpeedBat1;
    public GameObject AttackSpeedBat2;
    public GameObject AttackSpeedBat3;
    public GameObject AttackSpeedBat1Taken;
    public GameObject AttackSpeedBat2Taken;
    public GameObject AttackSpeedBat3Taken;

    public int DashLengthBat;
    public GameObject DashLengthBat1;
    public GameObject DashLengthBat2;
    public GameObject DashLengthBat3;
    public GameObject DashLengthBat1Taken;
    public GameObject DashLengthBat2Taken;
    public GameObject DashLengthBat3Taken;

    public int RageGainScythe;
    public GameObject RageGainScythe1;
    public GameObject RageGainScythe2;
    public GameObject RageGainScythe3;
    public GameObject RageGainScythe1Taken;
    public GameObject RageGainScythe2Taken;
    public GameObject RageGainScythe3Taken;

    public int AttackSpeedScythe;
    public GameObject AttackSpeedScythe1;
    public GameObject AttackSpeedScythe2;
    public GameObject AttackSpeedScythe3;
    public GameObject AttackSpeedScythe1Taken;
    public GameObject AttackSpeedScythe2Taken;
    public GameObject AttackSpeedScythe3Taken;

    public int DashLengthScythe;
    public GameObject DashLengthScythe1;
    public GameObject DashLengthScythe2;
    public GameObject DashLengthScythe3;
    public GameObject DashLengthScythe1Taken;
    public GameObject DashLengthScythe2Taken;
    public GameObject DashLengthScythe3Taken;

    [SerializeField]
    private Text rubieCount;

    [SerializeField]
    private Text rubieCountBat;

    [SerializeField]
    private Text rubieCountScythe;

    private bool isMuted;
    int highscoreNarc;
    [SerializeField]
    int rubies;
    public  static int choice;
    private int ScytheIsBought;

	void Start ()
	{
		isMuted = PlayerPrefs.GetInt("MUTED") == 1;
		AudioListener.pause = isMuted;
        PlayerPrefs.SetInt ("rubies", rubies);
        rubies = PlayerPrefs.GetInt ("rubies", rubies);
        ScytheIsBought = PlayerPrefs.GetInt ("scythe", ScytheIsBought);
        choice = 0;
        
        RageGainBat = PlayerPrefs.GetInt ("RageGain", RageGainBat);
        AttackSpeedBat = PlayerPrefs.GetInt ("AttackSpeed", AttackSpeedBat);
        DashLengthBat = PlayerPrefs.GetInt ("DashLength", DashLengthBat);
    
        RageGainScythe = PlayerPrefs.GetInt ("RageGain", RageGainScythe);
        AttackSpeedScythe = PlayerPrefs.GetInt ("AttackSpeed", AttackSpeedScythe);
        DashLengthScythe = PlayerPrefs.GetInt ("DashLength", DashLengthScythe);
    
    }
    void Update() 
    {
        rubieCount.text = "Rubies: " + rubies;
        rubieCountBat.text = "Rubies: " + rubies;
        rubieCountScythe.text = "Rubies: " + rubies;
        
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
        rubies = PlayerPrefs.GetInt ("rubies", rubies);
        
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
        
    }

    public void scythe()
    {
        choice = 2;
        
    }
    public void scytheNO()
    {
        if(rubies > 10){
            ScytheBuy.SetActive(true);
            Weapons.SetActive(false);
        }
    }

    public void Yes(){
        rubies = rubies - 10;
        PlayerPrefs.SetInt ("rubies", rubies);
        ScytheIsBought = 1;
        PlayerPrefs.SetInt ("scythe", ScytheIsBought);
    }

    public void weapon(){
        if(ScytheIsBought == 1){
            Scythe.SetActive(true);
            ScytheNO.SetActive(false);
        }
    }

 #region Bat related things
    public void batUpgrade(){

        RageGainBat = PlayerPrefs.GetInt ("RageGain", RageGainBat);
        AttackSpeedBat = PlayerPrefs.GetInt ("AttackSpeed", AttackSpeedBat);
        DashLengthBat = PlayerPrefs.GetInt ("DashLength", DashLengthBat);

        switch(RageGainBat)
        {
        case 1:
            RageGainBat1.SetActive(false);
            RageGainBat1Taken.SetActive(true);
            break;
        case 2:
            RageGainBat1.SetActive(false);
            RageGainBat2.SetActive(false);
            RageGainBat1Taken.SetActive(true);
            RageGainBat2Taken.SetActive(true);
            break;
        case 3:
            RageGainBat1.SetActive(false);
            RageGainBat2.SetActive(false);
            RageGainBat3.SetActive(false);
            RageGainBat1Taken.SetActive(true);
            RageGainBat2Taken.SetActive(true);
            RageGainBat3Taken.SetActive(true);
            break;
        }

        switch(AttackSpeedBat)
        {
        case 1:
            AttackSpeedBat1.SetActive(false);
            AttackSpeedBat1Taken.SetActive(true);
            break;
        case 2:
            AttackSpeedBat1.SetActive(false);
            AttackSpeedBat2.SetActive(false);
            AttackSpeedBat1Taken.SetActive(true);
            AttackSpeedBat2Taken.SetActive(true);
            break;
        case 3:
            AttackSpeedBat1.SetActive(false);
            AttackSpeedBat2.SetActive(false);
            AttackSpeedBat3.SetActive(false);
            AttackSpeedBat1Taken.SetActive(true);
            AttackSpeedBat2Taken.SetActive(true);
            AttackSpeedBat3Taken.SetActive(true);
            break;
        }

        switch(DashLengthBat)
        {
        case 1:
            DashLengthBat1.SetActive(false);
            DashLengthBat1Taken.SetActive(true);
            break;
        case 2:
            DashLengthBat1.SetActive(false);
            DashLengthBat2.SetActive(false);
            DashLengthBat1Taken.SetActive(true);
            DashLengthBat2Taken.SetActive(true);
            break;
        case 3:
            DashLengthBat1.SetActive(false);
            DashLengthBat2.SetActive(false);
            DashLengthBat3.SetActive(false);
            DashLengthBat1Taken.SetActive(true);
            DashLengthBat2Taken.SetActive(true);
            DashLengthBat3Taken.SetActive(true);
            break;
        }
    }

    public void BatRage1(){
        if(rubies >= 5)
        {    
            RageGainBat = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainBat);
        }
    }

    public void BatRage2(){
        if(rubies >= 5)
        {      
            RageGainBat = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainBat);
        }
    }    

    public void BatRage3(){
        if(rubies >= 5)
        {      
            RageGainBat = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainBat);
        }
    }

    
    public void BatAttack1(){
        if(rubies >= 5)
        {  
            AttackSpeedBat = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedBat);
        }
    }

    public void BatAttack2(){
        if(rubies >= 5)
        {  
            AttackSpeedBat = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedBat);
        }
    }

    public void BatAttack3(){
        if(rubies >= 5)
        {  
            AttackSpeedBat = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedBat);
        }
    }


    public void BatDash1(){
        if(rubies >= 5)
        {  
            DashLengthBat = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthBat);
        }
    }

    public void BatDash2(){
        if(rubies >= 5)
        {  
            DashLengthBat = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthBat);
        }
    }

    public void BatDash3(){
        if(rubies >= 5)
        {  
            DashLengthBat = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthBat);
        }
    }
    #endregion

    #region Scythe related things
    public void ScytheUpgrade(){

        RageGainScythe = PlayerPrefs.GetInt ("RageGain", RageGainScythe);
        AttackSpeedScythe = PlayerPrefs.GetInt ("AttackSpeed", AttackSpeedScythe);
        DashLengthScythe = PlayerPrefs.GetInt ("DashLength", DashLengthScythe);

        switch(RageGainScythe)
        {
        case 1:
            RageGainScythe1.SetActive(false);
            RageGainScythe1Taken.SetActive(true);
            break;
        case 2:
            RageGainScythe1.SetActive(false);
            RageGainScythe2.SetActive(false);
            RageGainScythe1Taken.SetActive(true);
            RageGainScythe2Taken.SetActive(true);
            break;
        case 3:
            RageGainScythe1.SetActive(false);
            RageGainScythe2.SetActive(false);
            RageGainScythe3.SetActive(false);
            RageGainScythe1Taken.SetActive(true);
            RageGainScythe2Taken.SetActive(true);
            RageGainScythe3Taken.SetActive(true);
            break;
        }

        switch(AttackSpeedScythe)
        {
        case 1:
            AttackSpeedScythe1.SetActive(false);
            AttackSpeedScythe1Taken.SetActive(true);
            break;
        case 2:
            AttackSpeedScythe1.SetActive(false);
            AttackSpeedScythe2.SetActive(false);
            AttackSpeedScythe1Taken.SetActive(true);
            AttackSpeedScythe2Taken.SetActive(true);
            break;
        case 3:
            AttackSpeedScythe1.SetActive(false);
            AttackSpeedScythe2.SetActive(false);
            AttackSpeedScythe3.SetActive(false);
            AttackSpeedScythe1Taken.SetActive(true);
            AttackSpeedScythe2Taken.SetActive(true);
            AttackSpeedScythe3Taken.SetActive(true);
            break;
        }

        switch(DashLengthScythe)
        {
        case 1:
            DashLengthScythe1.SetActive(false);
            DashLengthScythe1Taken.SetActive(true);
            break;
        case 2:
            DashLengthScythe1.SetActive(false);
            DashLengthScythe2.SetActive(false);
            DashLengthScythe1Taken.SetActive(true);
            DashLengthScythe2Taken.SetActive(true);
            break;
        case 3:
            DashLengthScythe1.SetActive(false);
            DashLengthScythe2.SetActive(false);
            DashLengthScythe3.SetActive(false);
            DashLengthScythe1Taken.SetActive(true);
            DashLengthScythe2Taken.SetActive(true);
            DashLengthScythe3Taken.SetActive(true);
            break;
        }
    }

    public void ScytheRage1(){
        if(rubies >= 5)
        {  
            RageGainScythe = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainScythe);
        }
    }

    public void ScytheRage2(){
        if(rubies >= 5)
        {  
            RageGainScythe = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainScythe);
        }
    }

    public void ScytheRage3(){
        if(rubies >= 5)
        {  
            RageGainScythe = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("RageGain", RageGainScythe);
        }
    }

    
    public void ScytheAttack1(){
        if(rubies >= 5)
        {  
            AttackSpeedScythe = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedScythe);
        }
    }

    public void ScytheAttack2(){
        if(rubies >= 5)
        {  
            AttackSpeedScythe = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedScythe);
        }
    }

    public void ScytheAttack3(){
        if(rubies >= 5)
        {  
            AttackSpeedScythe = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("AttackSpeed", AttackSpeedScythe);
        }
    }


    public void ScytheDash1(){
        if(rubies >= 5)
        {  
            DashLengthScythe = 1;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthScythe);
        }
    }

    public void ScytheDash2(){
        if(rubies >= 5)
        {  
            DashLengthScythe = 2;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthScythe);
        }
    }

    public void ScytheDash3(){
        if(rubies >= 5)
        {  
            DashLengthScythe = 3;
            rubies -= 5;
            PlayerPrefs.SetInt ("rubies", rubies);
            PlayerPrefs.SetInt ("DashLength", DashLengthScythe);
        }
    }
    #endregion
}

