using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Transform target;

    public bool m_FacingRight = true;  // For determining which way the enemy is currently facing.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }


    void Update()
    {


        if (transform.position.x < target.position.x)
        {
            // enemy is to the left side of the player, so move right

            if (!m_FacingRight)
            {
                Flip();
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
        if (transform.position.x > target.position.x)
        {
            if (m_FacingRight)
            {
                Flip();
                // enemy is to the left side of the player, so move left
                rb.velocity = new Vector2(-speed, 0);
            }
            else if (!m_FacingRight)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
        }
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    public void Flip()
    {

        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the enemys's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
