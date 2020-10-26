using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    //private float moveSpeed = 0.02f;
    private Vector2 screenBounds;
    public int maxHealth = 100;
    int currentHealth;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public int attackDamage = 1;
    public bool isDead = false;
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * 1.5)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y > screenBounds.y)
        {
            Destroy(this.gameObject);
        }


        //transform.Translate(Vector2.right * moveSpeed);

        /*void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                Debug.Log("collision detected!");
                Destroy(gameObject);
            }
        }*/


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("EnemyHit");

        //Play hurt animation

        if (currentHealth <= 0)
        {
            Instantiate (blood, transform.position, Quaternion.identity);
            Die();
            FindObjectOfType<AudioManager>().Play("EnemyDead");
        }




    }
    public void Die()
    {
        ScoreScript.scoreValue += 100;
        Destroy(this.gameObject);
        isDead = true;
    }

    public void Attack()
    {
        //Play an attack animation
        //animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        //Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        // Damage them
        //foreach (Collider2D move in hitPlayer)
        //{
        //    Move.GetComponent<Move>().TakeDamage(attackDamage);
//
       // }

    }
}
