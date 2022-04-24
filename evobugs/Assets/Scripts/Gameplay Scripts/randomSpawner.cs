using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7;
    private float time= 1.5f;
    //array of enemies:
    public GameObject[] enemyArray;




    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy(){

        //vector2 = position of player
        Vector2 spawnPos = GameObject.Find("Player").transform.position;

        //specify the spawn position of enemy = somewhere within a radius of the player
        spawnPos += Random.insideUnitCircle.normalized*spawnRadius;

        //spawn a random enemy from the enemeis array at the specified spawn position, quaternon identity for rotation
        Instantiate(enemyArray[Random.Range(0, enemyArray.Length)], spawnPos, Quaternion.identity);

        //create an intervaled loop; wait some time, and re-call the function to spawn another enemy
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
