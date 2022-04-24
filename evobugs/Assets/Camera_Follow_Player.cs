using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour {

    public Transform player;
    public Transform leftBound;
    public Transform rightBound;
    public Transform upBound;
    public Transform downBound;

    void Update () {

        Vector3 pos = player.transform.position;
        
        float lb = leftBound.transform.position.x + 9 ;
        float rb = rightBound.transform.position.x - 9 ;
        float ub = upBound.transform.position.y - 4 ;
        float db = downBound.transform.position.y + 4;

        if(pos.x < lb)
            pos.x = lb;
        if(pos.x > rb)
            pos.x = rb;
        if(pos.y > ub)
            pos.y = ub;
        if(pos.y < db)
            pos.y = db;
        
        transform.position = pos + new Vector3(0, 0, -1);
    }
}