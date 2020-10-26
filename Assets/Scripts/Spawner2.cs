using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spawner2 : MonoBehaviour
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
            xPos = UnityEngine.Random.Range(-25, -15);
            yPos = -4;
            Instantiate(theEnemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(1f, 5f));
            enemyCount += 1;
        }
    }
}