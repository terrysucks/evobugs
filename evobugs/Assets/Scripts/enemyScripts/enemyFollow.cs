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
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(Vector2.Distance(transform.position, playerPos.position) > 0.25f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);

        Vector2 facingDirection = playerPos.position - transform.position;
        float aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            aimAngle - 90
        );    
    }
}
