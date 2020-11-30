using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
//using UnityStandardAssets.CrossPlatformInput;


public class Move : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    public GameObject MainChar;
    public GameObject död;
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
    //float nextAttackTime = 0f;
    private bool IsAttacking = false;
    private bool Left = false;
    private bool Right = false;
    private bool MouseLeft = false;
    private bool MouseRight = false;
    public float position;
    private int d = 0;
    private int i;
    

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
    private bool IsDashing;
    private bool DashLeft;
    private bool DashRight;
    private bool toimisko = false;
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
        dashaus = GetComponent<SwipeTest>().dashTime;

        MainChar.SetActive(true);
        död.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position.x;
        tap = tapLeft = tapRight = swipeLeft = swipeRight = false;
        //DashLeft = GetComponent<SwipeTest>().DashLeft;
        //DashRight = GetComponent<SwipeTest>().DashRight;
        död.transform.position = MainChar.transform.position;
        död.transform.rotation = MainChar.transform.rotation;
        
        
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
                IsDashing = false;
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
        if(swipeDelta.magnitude > 110)
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
                    if(m_FacingRight){
                        Flip();
                    }
                }  
                else{
                    swipeRight = true;
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
            
            //Vector3 touchPosition = Input.GetTouch( 0 ).position;
            touchPosition.z =0;
            touchPosition.y =-4;
            //direction = (touchPosition - transform.position);
            //rb.velocity = new Vector2(direction.x, direction.y * moveSpeed);
            // Which direction?
            
             
            if (touchPosition.x > rb.position.x)
            {
                if (m_FacingRight)
                {
                    //if(Time.time >= nextAttackTime){
                    //transform.Translate (Vector3.right * moveSpeed);
                    tapRight = true;
                    Attack();
                    //Moves();
                    
                    //}
                }
                else 
                {
                    Flip();
                    //if(Time.time >= nextAttackTime){
                    //transform.Translate (Vector3.right * moveSpeed);
                    tapRight = true;
                    Attack();                   
                    //Moves();
                    
                    //}
                }
                
            }
            if (touchPosition.x < rb.position.x)
            {
                if(m_FacingRight)
                {
                    Flip();
                    //if(Time.time >= nextAttackTime){
                    //transform.Translate (Vector3.left * moveSpeed);
                    tapLeft = true;
                    Attack();
                    //Moves();
                    
                    //}
                }
                else
                {
                    //if(Time.time >= nextAttackTime){
                    //transform.Translate (Vector3.left * moveSpeed);
                    tapLeft = true;
                    Attack();
                    //Moves();
                    
                    //}
                }

                
            }
                
        }
        //BASIC TOUCH MOVE & ATTACK ////////////////////////////////END
        #endregion   
        
        #region Keyboard move & attack
        //KEYBOARD MOVE & ATTACK////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Left = true;
            //transform.Translate (Vector3.left * moveSpeed);
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
            //transform.Translate (Vector3. right * moveSpeed);
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

        //dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        //rb.velocity = new Vector2(dirX, 0f);
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
                //Die();
            }
        }
        //QUITE SELF EXPALAINATORY///////

        #region Dash
        //DASH////////////////////////////////////////
        if(dir == 0){
            if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)){
                dir = 1;
                
                
            } else if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)){
                dir = 2;
                
                
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
                    Dash();
                }else if(dir == 2){
                    DashRight = true;
                    Dash();
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
            //nextAttackTime = Time.time + 1f / attackRate;
            direction = (touchPosition - transform.position);
            //rb.velocity = new Vector2(direction.x, direction.y * moveSpeed);
            //dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        
           
            
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
                        playerHealth++;
                        rageBar.SetHealth(playerHealth);
                        rageBar1.SetHealth(playerHealth);
                    }
                }
                //nextAttackTime = Time.time + 1f / attackRate;
                direction = (touchPosition - transform.position);
                //rb.velocity = new Vector2(direction.x, direction.y * moveSpeed);
                //dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            }else {
               // Damage them
               
                foreach(Collider2D enemy in hitEnemies)
                {
                    Debug.Log(enemy);
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

                    if (enemy.GetComponent<Enemy>().isDead)
                    {
                        playerHealth++;
                        rageBar.SetHealth(playerHealth);
                        rageBar1.SetHealth(playerHealth);
                    }
                }
                //nextAttackTime = Time.time + 1f / attackRate;
                direction = (touchPosition - transform.position);
                //rb.velocity = new Vector2(direction.x, direction.y * moveSpeed);
                //dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed; 
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
            //animator.SetTrigger("Dash");
            IsDashing = true;
            rageBar.SetHealth(playerHealth);
            rageBar1.SetHealth(playerHealth);
            d++;
            

            if(GetComponent<SwipeTest>().DashLeft == true || DashLeft == true){
                
                animator.SetTrigger("Dash");
                rb.velocity = Vector2.left * dashSpeed;
                DashLeft = false;
                //Debug.Log("Tuleeko vasen " + GetComponent<SwipeTest>().DashLeft + DashLeft);
            }else if (GetComponent<SwipeTest>().DashRight == true || DashRight == true){
                
                animator.SetTrigger("Dash");
                rb.velocity = Vector2.right * dashSpeed;
                DashRight = false;
                //Debug.Log("Tuleeko oikia " + GetComponent<SwipeTest>().DashRight + DashRight);
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
                //animator.ResetTrigger("Dash");
                
        }
        d = 0;
        
    }

    //private void OnCollisionStay2D(Collision2D collision)
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy"  /*&& !IsDashing*/)
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
        //animator.SetTrigger("Death");
        paussiMenu.Death();
    }
    
    private void Reset() {

        startTouch = swipeDelta = Vector2.zero;
        IsDraging = false;
    }

    private void ResetAttack(){

        IsAttacking = false;
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
  