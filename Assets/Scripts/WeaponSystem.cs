using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class WeaponSystem : MonoBehaviour
{
    public GameObject BaseballBat;
    public GameObject Scythe;
    public GameObject ScytheNO;
    public GameObject ScytheBuy;

    [SerializeField]
    private Text rubieCount;

    [SerializeField]
    int rubies;

    public  static int choice;
    private bool ScytheIsBought = false;
    // Start is called before the first frame update
    void Start()
    {
        rubies = PlayerPrefs.GetInt ("rubies", rubies);
        ScytheIsBought = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScytheIsBought == false && rubies < 10){
            ScytheNO.SetActive(true);
        }else if (ScytheIsBought == true){
            Scythe.SetActive(true);
            ScytheNO.SetActive(false);
        }
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
    public void scytheNO()
    {
        if(rubies > 10 && ScytheIsBought == false ){
            ScytheBuy.SetActive(true);
        }
    }

    public void Yes(){
        rubies = 200;//rubies - 10;
        PlayerPrefs.SetInt ("rubies", rubies);
        ScytheIsBought = true;
        ScytheBuy.SetActive(false);
        Debug.Log(ScytheIsBought);
    }

    public void No(){
        ScytheBuy.SetActive(false);
        
    }
}
