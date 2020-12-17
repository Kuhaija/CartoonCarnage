using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Move : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    public GameObject Player;
    public GameObject MainChar;
    public GameObject dead;
    private float dirX;
    private float moveSpeed = 0.5f;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 100;
    public int damageMultiplier = 3;
    private int dashDamage;
    public int playerHealth = 1;
    public float attackRate = 2f;
    private bool IsAttacking = false;
    private bool Left = false;
    private bool Right = false;
    public float position;
    private int d = 0;
    private int i;
    public static int rubies;
    private Vector2 PosForCam;
    private Vector2 PlayerPos;
     [SerializeField]
    private Text rubieCount;
    
    //From Other Script///////////////
    private int RageGainBat;
    private int AttackSpeedBat;
    private int DashLengthBat;
    public int rageGain;
    private int RageGainScythe;
    private int AttackSpeedScythe;
    private int DashLengthScythe;
    //////////////////////////////////


    //public float CollisionTime = 2f;
    Touch touch;
    public Vector3 touchPosition;
    public RageBar rageBar;
    public RageBar rageBar1;
    public PaussiMenu paussiMenu;

    private Vector2 direction;
    
    float damageTime = 0.05f;
    float currentDamageTime;

    //DASH///////////////////
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private int dir;
    private float dashaus;
    private bool DashLeft;
    private bool DashRight;
    
    //DASH//////////////////

    //SWIPE/////////////////////
    
    private bool tap,tapLeft,tapRight,swipeLeft,swipeRight;
    private bool tapRequested;
    private bool IsDraging =false;
    private Vector2 startTouch, swipeDelta;
    
    //SWIPE/////////////////////


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = true;
        i = 0;
        rageBar.SetHealth(playerHealth);
        rageBar1.SetHealth(playerHealth);
        dashTime = startDashTime;
        MainChar.SetActive(true);
        dead.SetActive(false);
        rubies = PlayerPrefs.GetInt ("rubies", rubies);

        RageGainBat = PlayerPrefs.GetInt ("RageGainBat", RageGainBat);
        AttackSpeedBat = PlayerPrefs.GetInt ("AttackSpeedBat", AttackSpeedBat);
        DashLengthBat = PlayerPrefs.GetInt ("DashLengthBat", DashLengthBat);

        RageGainScythe = PlayerPrefs.GetInt ("RageGainScythe", RageGainScythe);
        AttackSpeedScythe = PlayerPrefs.GetInt ("AttackSpeedScythe", AttackSpeedScythe);
        DashLengthScythe = PlayerPrefs.GetInt ("DashLengthScythe", DashLengthScythe);
        
        switch (RageGainBat)
        {
            case 1:
                rageGain = 2;
                break;
            case 2:
                rageGain = 4;
                break;
            case 3:
                rageGain = 7;
                break;
            default:
                rageGain = 1;
                break;
        }

        switch (AttackSpeedBat)
        {
            case 1:
                animator.SetFloat("speed", 1.25f);
                break;
            case 2:
                animator.SetFloat("speed", 1.5f);
                break;
            case 3:
                animator.SetFloat("speed", 1.75f);
                break;
            default:
                animator.SetFloat("speed", 1f);
                break;
        }

        switch (DashLengthBat)
        {
            case 1:
                dashSpeed += 2;
                break;
            case 2:
                dashSpeed += 4;
                break;
            case 3:
                dashSpeed += 6;
                break;
            default:
                
                break;
        }


        switch (RageGainScythe)
        {
            case 1:
                rageGain = 2;
                break;
            case 2:
                rageGain = 4;
                break;
            case 3:
                rageGain = 7;
                break;
            default:
                rageGain = 1;
                break;
        }

        switch (AttackSpeedScythe)
        {
            case 1:
                animator.SetFloat("speed", 1.25f);
                break;
            case 2:
                animator.SetFloat("speed", 1.5f);
                break;
            case 3:
                animator.SetFloat("speed", 1.75f);
                break;
            default:
                animator.SetFloat("speed", 1f);
                break;
        }

        switch (DashLengthScythe)
        {
            case 1:
                dashSpeed += 2;
                break;
            case 2:
                dashSpeed += 4;
                break;
            case 3:
                dashSpeed += 6;
                break;
            default:
                
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position.x;
        tap = tapLeft = tapRight = swipeLeft = swipeRight = false;
        dead.transform.position = MainChar.transform.position;
        dead.transform.rotation = MainChar.transform.rotation;
        
        rubieCount.text = ": " + rubies;
        
        #region Swipe
        //SWIPE/////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0)){
            tapRequested = true;
            IsDraging = true;
            
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0)){
            IsDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tapRequested = true;
                IsDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                if (tapRequested) { tap = true; }
                IsDraging = false;
                Reset();
            }
        }
        #endregion

        // Calculate the distance
        swipeDelta = Vector2.zero; 
        // Player touches the screen
        if(IsDraging)
        {
            // We started the touch somewhere
            if(Input.touchCount > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Did we cross the deadzone?
        if(swipeDelta.magnitude > 120)
        {
            tapRequested = false;
            tapLeft = tapRight = false;
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if(x < 0){
                    swipeLeft = true;
                    swipeRight = false;
                    if(m_FacingRight){
                        Flip();
                    }
                }  
                else if(x > 0){
                    swipeRight = true;
                    swipeLeft = false;
                    if(!m_FacingRight){
                        Flip();
                    }
                }
            }  

            Reset();
        }
        //SWIPE////////////////////////////////////////////
        #endregion
        
        #region basic touch move & attack
        //BASIC TOUCH MOVE & ATTACK ////////////////////////////////
        if (tap)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z =0;
            touchPosition.y =-4;            
            // Which direction?
            
             
            if (touchPosition.x > rb.position.x)
            {
                if (m_FacingRight)
                {
                    tapRight = true;
                    Attack();
                }
                else 
                {
                    Flip();                    
                    tapRight = true;
                    Attack();
                }
                
            }
            if (touchPosition.x < rb.position.x)
            {
                if(m_FacingRight)
                {
                    Flip();                    
                    tapLeft = true;
                    Attack();
                    
                }
                else
                {                    
                    tapLeft = true;
                    Attack();                    
                }

                
            }
                
        }
        //BASIC TOUCH MOVE & ATTACK ////////////////////////////////END
        #endregion   
        
        #region Keyboard move & attack
        //KEYBOARD MOVE & ATTACK////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Left = true;
            if(m_FacingRight){
                Flip();
                Attack();
            } 
            else{
                Attack();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Right = true;
            if(m_FacingRight){
                Attack();
            }
            else{
                Flip();
                Attack();
            }
        }
        //KEYBOARD MOVE & ATTACK////////////////////////////////////END
        #endregion

        
        {
            Moves();
        }

        //QUITE SELF EXPALAINATORY///////
        if (playerHealth <= 0)
        {
            if(i < 1){
                animator.SetTrigger("Death");
                rb.simulated = false;
                i++;
            }
        }
        //QUITE SELF EXPALAINATORY///////

        #region Dash
        //DASH////////////////////////////////////////
        if(dir == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) || swipeLeft == true){
                DashLeft = true;
                DashRight = false;
                dir = 1;
                Dash();
                swipeLeft = false;
                
            } else if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift) || swipeRight == true){
                DashLeft = false;
                DashRight = true;
                dir = 2;
                Dash();
                swipeRight = false;
                
            }
        }else {
            if(dashTime <= 0){
                dir = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else{
                dashTime -= Time.deltaTime;

                if(dir == 1){
                    DashLeft = true;
                    
                }else if(dir == 2){
                    DashRight = true;
                    
                }
            }
        }
        //DASH//////////////////////////////////////////////////////////////////////////////////////////////
        #endregion
    
       
    }
    
    public void Moves()
    {

        // If the input is moving the player right and the player is facing left...
        if (dirX > 0 )
        {
            // ... flip the player.
            if (!m_FacingRight)
            {
                Flip();
                
            }
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (dirX < 0)
        {
            if (m_FacingRight)
            {
                // ... flip the player.
                Flip();
                
            }
        }

        

    }
    public void Flip()
    {
        
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        
    }

     public void Attack()
    {
        
        if(!IsAttacking){
        //Play an attack animation
            IsAttacking = true;
            animator.SetTrigger("Attack");
            if(Left || tapLeft){
                transform.Translate (Vector3.left * moveSpeed);
                Left = false;
                tapLeft = false;
            }else if(Right || tapRight){
                transform.Translate (Vector3.right * moveSpeed);
                Right = false;
                tapRight = false;
            }
            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            // Damage them
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

                if (enemy.GetComponent<Enemy>().isDead)
                {
                    playerHealth++;
                    rageBar.SetHealth(playerHealth);
                    rageBar1.SetHealth(playerHealth);
                }
            }
            direction = (touchPosition - transform.position);
            
        }
    }

    public void Damage(){
        // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            if(dashTime <= 0){
                // Damage them
                dashDamage = attackDamage * damageMultiplier;
                foreach(Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(dashDamage);

                    if (enemy.GetComponent<Enemy>().isDead)
                    {
                        playerHealth += rageGain;
                        rageBar.SetHealth(playerHealth);
                        rageBar1.SetHealth(playerHealth);
                    }
                }                
                direction = (touchPosition - transform.position);            
            }else {
               // Damage them
               
                foreach(Collider2D enemy in hitEnemies)
                {
                    //Debug.Log(enemy);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

                    if (enemy.GetComponent<Enemy>().isDead)
                    {
                        playerHealth += rageGain;
                        rageBar.SetHealth(playerHealth);
                        rageBar1.SetHealth(playerHealth);
                    }
                }
                
                direction = (touchPosition - transform.position);               
            }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Dash(){
        if(playerHealth > 5 && d < 1){    
            playerHealth -= 5;        
            rageBar.SetHealth(playerHealth);
            rageBar1.SetHealth(playerHealth);
            d++;
            

            if(DashLeft == true || swipeLeft == true){                
                animator.SetTrigger("Dash");
                rb.velocity = Vector2.left * dashSpeed;
                DashLeft = false;
                swipeLeft = false;
                
            }else if (DashRight == true || swipeRight == true){                
                animator.SetTrigger("Dash");
                rb.velocity = Vector2.right * dashSpeed;
                DashRight = false;
                swipeRight = false;
            }
            
            // Detect enemies in range of attack
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                
                // Damage them
                foreach(Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

                    if (enemy.GetComponent<Enemy>().isDead)
                    {
                        playerHealth += rageGain;
                        rageBar.SetHealth(playerHealth);
                        rageBar1.SetHealth(playerHealth);
                    }
                }
        }
        d = 0;
        
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {   
            currentDamageTime += Time.deltaTime;
            if(currentDamageTime > damageTime) {
                FindObjectOfType<AudioManager>().Play("PlayerDamaged");
                playerHealth--;
                rageBar.SetHealth(playerHealth);
                rageBar1.SetHealth(playerHealth);
                currentDamageTime = 0.0f;
            }
        }
            
    }

    private void Die()
    {
        paussiMenu.Death();
    }
    
    private void Reset() {

        startTouch = swipeDelta = Vector2.zero;
        IsDraging = false;
    }

    private void ResetAttack(){

        IsAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("rubies"))
                {
                     rubies++;
                     Destroy(other.gameObject);
                     PlayerPrefs.SetInt ("rubies", rubies);
                }
    }
    

    #region For Swipe
    public bool Tap {get {return tap;}}
    public bool TapLeft {get {return tapLeft;}}
    public bool TapRight {get {return tapRight;}}
    public Vector2 SwipeDelta {get{ return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    #endregion
}
  