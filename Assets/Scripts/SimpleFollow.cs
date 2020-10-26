using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public float speed;

    private Transform target;
    
    void Start() { 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    
        
    }

    
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}
