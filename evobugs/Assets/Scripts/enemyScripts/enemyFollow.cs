using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyFollow : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private Transform enemyPos;
    public GameObject[] mobPositionArr;

    public float distFromPlayer, distFromMob;

    WaitForSeconds starveInterval= new WaitForSeconds(1);


    //[+] points = health = damage = size multiplier
    [SerializeField]   //<-- makes the fields visible in the unity inspector
    private int points = 100;
    private bool hit = true;
    int counter = 0;



 



    void Awake()
    {
        //player position
        playerPos = GameObject.FindWithTag("Player").transform;

        //position of other enemies
        enemyPos = GameObject.FindWithTag("enemy").transform;
        //mobPositionArr = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // if enemy is a certain distance from player/other enemy, move towards player/other enemy
        distFromPlayer = Vector2.Distance(transform.position, playerPos.position);
        distFromMob = Vector2.Distance(transform.position, enemyPos.position);


        if(distFromPlayer > .25f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);
        // else{
        //     transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -2*speed*Time.deltaTime);
        // }

        if((distFromMob > 3f)   )
            transform.position = Vector2.MoveTowards(transform.position, enemyPos.position, speed*Time.deltaTime);
        // else{
        //     transform.position = Vector2.MoveTowards(transform.position, enemyPos.position, -5*speed*Time.deltaTime);
        // }

        if( counter > 10000){counter = 0;}
        else{ counter++; }
        
        if ( (counter%50) == 0){
            StartCoroutine(Starve());
        }
        
        
    }

    //[+] ----------- Code for Taking Damage-------------[+]
//NOTE: make sue "is trigger" box is checked in the 'Box Collider 2D" component in the inspector
    IEnumerator HitBoxOff(){
        hit= false;
        yield return new WaitForSeconds(1.5f);
    }
    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "enemy"){
            if(hit){ 
                points--;
            }
        }
    }


    IEnumerator Starve(){
        int i= 100;
        while (i>0)
        {
            points--;
            i--;
            yield return starveInterval;
        }
        
        
    }
//[+]------------------------------------------------[+]

}
