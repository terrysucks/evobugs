using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroomSpawn : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 10;
    private float time= 1.5f;
    private int population;
    //array of enemies:



    public GameObject[] foodArray;
    




    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    void Awake(){
        population = GameObject.FindGameObjectsWithTag("enemy").Length;
        
    }

    IEnumerator SpawnFood(){

        //vector2 = position of player
        Vector2 spawnPos = GameObject.Find("Player").transform.position;

        //specify the spawn position of enemy = somewhere within a radius of the player
        spawnPos += Random.insideUnitCircle.normalized*spawnRadius;

        //spawn a random enemy from the enemeis array at the specified spawn position, quaternon identity for rotation
        if(population < 15){
            Instantiate(foodArray[Random.Range(0, foodArray.Length)], spawnPos, Quaternion.identity);
        }

        //create an intervaled loop; wait some time, and re-call the function to spawn another enemy
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnFood());
    }
}
