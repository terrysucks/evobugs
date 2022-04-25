using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 0.25f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);
    }
}
