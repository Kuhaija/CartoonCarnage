using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Spawner3 : MonoBehaviour
{
    public GameObject theEnemy;
    public float HowFar = 16;
    public float xPos;
    public int yPos;
    public int enemyCount;
    public float wait_time;
    private float PlayerLocation;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        PlayerLocation = GetComponent<Move>().position;
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 100)
        {
            xPos = PlayerLocation + HowFar;
            yPos = -4;
            Instantiate(theEnemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(2f, 6f));
            enemyCount += 1;
        }
    }
}