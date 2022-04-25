using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField]
    public int points = 7;
    private bool hit = true;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(points < 1){ Destroy(gameObject);}
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "enemy"){
            if(hit){ points--;}
        }
    }

}
