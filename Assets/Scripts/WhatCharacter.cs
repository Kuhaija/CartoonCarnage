using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatCharacter : MonoBehaviour
{
    public GameObject DudeWithABat;
    public GameObject DudeWithAScythe;
    private int choice;

    // Start is called before the first frame update
    void Start()
    {
        choice = MainMenu.choice;

       if(choice == 1){
            DudeWithABat.SetActive(true);
            DudeWithAScythe.SetActive(false);
        }
        if(choice == 2){
            DudeWithAScythe.SetActive(true);
            DudeWithABat.SetActive(false);  
        } 
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
}
