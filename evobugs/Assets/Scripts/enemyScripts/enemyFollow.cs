using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemyFollow : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private Rigidbody2D rb;
    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate for physics stuff
    void FixedUpdate()
    {
        //if(Vector2.Distance(transform.position, playerPos.position) > 0.25f)
        //    transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);

        // Face the player, then within the 0.25 distance threshold, advance toward player via Rigidbody2D
        transform.right  = transform.position - playerPos.transform.position;
        if (Vector2.Distance(transform.position, playerPos.position) > 0.25f)
        {
            rb.velocity = transform.right * -speed;
        }
    }
}
