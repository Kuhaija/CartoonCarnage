using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DASHSAATANA : MonoBehaviour
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
    private bool dashTimeri;
    public float aika;
    private int i = 0;
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
                //transform.Translate (Vector3.left * 3f );
                //desiredSpeed = 10f;
                //Debug.Log("SWIPEVASEN");
                dir = 1;
            }
            if (swipeControls.SwipeRight){
                //transform.Translate (Vector3.right * 3f );
                //desiredSpeed = 10f;
                //Debug.Log("SWIPEOIKIA");
                dir = 2;
            }
        //player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, desiredSpeed * Time.deltaTime);
        }else {
            if(dashTimeri == false){
                dir = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                //Debug.Log("Kui monesti tää välimalli tulee");
                dashaako = false;
                 if (i < 1){
                     StartCoroutine(timer());
                     i++;
                 }
            } else{
                
                Debug.Log("tulleeko tää " + dashTimeri);
                //dashTime -= Time.fixedDeltaTime;

                if(dir == 1){
                    if(!dashaako && dashTimeri == true){
                        Debug.Log("vasen " + dashTimeri);
                        //rb.velocity = Vector2.left * dashSpeed;
                        DashLeft = true;
                        GetComponent<Move>().Dash();
                        
                        //Debug.Log("Kui monesti vasen?");
                        dashaako = true;
                    }
                }else if(dir ==2){
                    if(!dashaako && dashTimeri == true){
                        Debug.Log("oikea " + dashTimeri);
                        //rb.velocity = Vector2.right *dashSpeed;
                        DashRight = true;
                        GetComponent<Move>().Dash();
                        
                        //Debug.Log("Kui monesti oikia?");
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

    IEnumerator timer(){
        dashTimeri = true;
        Debug.Log("NO " + dashTimeri);
        yield return new WaitForSeconds(aika);
        dashTimeri = false;
        i = 0;
    }
}

