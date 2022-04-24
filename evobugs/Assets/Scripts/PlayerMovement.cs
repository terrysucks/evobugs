using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField]   //<-- makes the fields visible in the unity inspector
    private int points = 1000;
    private bool hit = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x*moveSpeed, moveDirection.y*moveSpeed);
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
//[+]------------------------------------------------[+]



}
