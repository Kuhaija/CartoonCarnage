﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spawner4 : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int yPos;
    public int enemyCount;
    public float wait_time;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 100)
        {
            xPos = UnityEngine.Random.Range(-20, -15);
            yPos = -4;
            Instantiate(theEnemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(3f, 7f));
            enemyCount += 1;
        }
    }
}