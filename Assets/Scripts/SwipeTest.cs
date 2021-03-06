﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    //SWIPE///////////////////////
    public Move swipeControls;
    public Transform player;
    private Vector3 desiredPosition;
    private float desiredSpeed;
    

    ///////////////////////////////

    //DASH//////////////////////////
    private Rigidbody2D rb;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private int dir;
    private bool dashaako = false;
    private int health;
    public bool DashLeft = false;
    public bool DashRight = false;
    //////////////////////////////////

    // Update is called once per frame
    
    void Start() {
        
        desiredPosition = player.position; 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        health = GetComponent<Move>().playerHealth;
        DashLeft = DashRight = false;
        
        if (dir == 0 && health > 5 && (swipeControls.SwipeLeft || swipeControls.SwipeRight)){
            if (swipeControls.SwipeLeft){
                
                dir = 1;
            }
            if (swipeControls.SwipeRight){
                
                dir = 2;
            }
        }else {
            if(dashTime <= 0){
                dir = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                
                dashaako = false;
            } else{
                dashTime -= Time.deltaTime;

                if(dir == 1){
                    if(!dashaako){
                        
                        DashLeft = true;
                        GetComponent<Move>().Dash();
                        dashaako = true;
                    }
                }else if(dir ==2){
                    if(!dashaako){
                        
                        DashRight = true;
                        GetComponent<Move>().Dash();
                        dashaako = true;
                    }
                }
            }
        }



        if (swipeControls.TapLeft || swipeControls.TapRight){
            if (swipeControls.TapLeft){
                //transform.Translate (Vector3.left * 0.5f);
            }
            if (swipeControls.TapRight){
                //transform.Translate (Vector3.right * 0.5f);
            }
        

        }
        
    }
}
