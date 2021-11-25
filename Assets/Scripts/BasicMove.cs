using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int jumpStrength = 10;
    public bool canJump = false;
    public int moveSpeed = 5;
    public int maxSpeed =  10;
    public int dampen = 2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && canJump){
            rb.velocity += Vector2.up*jumpStrength;
            canJump = false;
            //canMove = false;
        }
        if(canJump){
            if(Input.GetAxis("Horizontal") < 0){
                float yVel = rb.velocity.y;
                rb.velocity = Vector2.zero;
                rb.velocity += new Vector2(-1*moveSpeed, yVel);
            }else if(Input.GetAxis("Horizontal") > 0){
                float yVel = rb.velocity.y;
                rb.velocity = Vector2.zero;
                rb.velocity += new Vector2(1*moveSpeed, yVel);
            }else{
                float yVel = rb.velocity.y;
                rb.velocity = new Vector2(0, yVel);
            }
        }else{
            if(Input.GetAxis("Horizontal") < 0){
                rb.AddForce(Vector2.left/dampen);
            }
            if(Input.GetAxis("Horizontal") > 0){
                rb.AddForce(Vector2.right/dampen);
            }
            if(rb.velocity.x > maxSpeed){
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            if(rb.velocity.x < -maxSpeed){
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);

            }
        }else if(Input.GetAxis("Horizontal") > 0){
            //rb.velocity += Vector2.down*gravity;
            rb.velocity += Vector2.right*moveSpeed;
            if(Math.Abs(rb.velocity.x) > maxspeed){
                rb.velocity = new Vector2(maxspeed,rb.velocity.y);
            }
        }

        if(rb.velocity.y < -maxspeed){
            rb.velocity = new Vector2(rb.velocity.x,-maxspeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
