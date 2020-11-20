using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVol666 : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject theEnemy;
    private int randEnemy;
    private float HowFar;
    public float xPos;
    private int[] xValues = {13, 14, -13, -14};
    public int enemyCount;
    public float wait_time;
    private float PlayerLocation;
    private int Points = 0;
    private float speedO;
    private int i;
    public static int JOKO;
    

    void Start()
    {
        
        PlayerLocation = GetComponent<Move>().position;
        Points = ScoreScript.scoreValue;
        theEnemy = enemies[Random.Range (0, enemies.Length)];
        HowFar = xValues[Random.Range (0, xValues.Length)];
        //speedO = SimpleFollow.speed;
        StartCoroutine(SpawnEnemy());
        //SpawnEnemy();
    }

    void Update()
    {
        PlayerLocation = GetComponent<Move>().position;
        Points = ScoreScript.scoreValue;
        theEnemy = enemies[Random.Range (0, enemies.Length)];
        HowFar = xValues[Random.Range (0, xValues.Length)];
        //speedO = SimpleFollow.speed;
        
    }

    /*IEnumerator EnemyDrop()
    {
        while (enemyCount < 100)
        {
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(2f, 6f));
            enemyCount += 1;
        }
    }*/
    IEnumerator SpawnEnemy(){

            
            
        
        while(Points < 1000 && enemyCount <= 15) {
            while(i <= 1){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(1f, 3f));
            enemyCount += 1;
            JOKO = 1;
        }
        while (Points >= 1000 && Points < 2500) {
            while(i <= 2){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(1f, 2.5f));
            enemyCount += 1;
            JOKO = 2;
        }
        while(Points >= 2500 && Points < 5000 ) {
            while(i <= 3){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(0.5f, 2f));
            enemyCount += 1;
            JOKO = 3;
        }
        while(Points >= 5000  && Points < 10000) {
            while(i <= 4){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(0.5f, 1f));
            enemyCount += 1;
            JOKO = 4;
        }
        while(Points >= 10000  && Points < 15000) {
            while(i <= 5){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(0.5f, 0.75f));
            enemyCount += 1;
            JOKO = 5;
        }
        while( Points >= 10000  && Points < 10000000 ) {
            while(i <= 6){
                speedO += 0.5f;
                i ++;
                }
            xPos = PlayerLocation + HowFar;
            Instantiate(theEnemy, new Vector3(xPos, -4, 0), Quaternion.identity);
            yield return new WaitForSeconds(wait_time = UnityEngine.Random.Range(0.5f, 0.75f));
            enemyCount += 1;
            JOKO = 6;
        }
    }
}
