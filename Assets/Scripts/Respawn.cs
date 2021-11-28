using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Transform player = this.gameObject.GetComponent<Transform>();
        if(player.position.y < -10){
            player.position = new Vector3(-5f,-1.5f,1f);
        }
    }
}
