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
    public int maxSpeed = 10;
    public float dampen = 0.5f;
    private SpriteRenderer thisSprite;
    private AudioSource jumpAudio; 
    public bool onGround;
    public Vector2 bottomOffset;
    // public float jumpDelay = 0;
    // private float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thisSprite = GetComponent<SpriteRenderer>();
        jumpAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //manage if player can jump
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, 0.4f);
        if(onGround && Math.Abs(rb.velocity.y) < 0.05f){
            canJump=true;
        }else{
            canJump=false;
        }
        

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity += Vector2.up * jumpStrength;
            jumpAudio.Play();
            //Debug.Log("onGround: "+onGround);
        }
        if (canJump)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                float yVel = rb.velocity.y;
                rb.velocity = Vector2.zero;
                rb.velocity += new Vector2(-1 * moveSpeed, yVel);
                thisSprite.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                float yVel = rb.velocity.y;
                rb.velocity = Vector2.zero;
                rb.velocity += new Vector2(1 * moveSpeed, yVel);
                thisSprite.flipX = false;
            }
            else
            {
                float yVel = rb.velocity.y;
                rb.velocity = new Vector2(0, yVel);
            }
        }
        
    }
    void FixedUpdate(){
        if(!canJump)
        {
            //Debug.Log(rb.velocity.x+Vector2.left.x > -maxSpeed);
            if(rb.velocity.x+Vector2.left.x > -maxSpeed){
                if (Input.GetAxis("Horizontal") < 0)
                {
                    thisSprite.flipX = true;
                    rb.AddForce(Vector2.left / dampen);
                    //rb.AddForce(Vector2.left * dampen);
                }
            }
            if(rb.velocity.x+Vector2.right.x < maxSpeed){
                if (Input.GetAxis("Horizontal") > 0)
                {
                    thisSprite.flipX = false;
                    rb.AddForce(Vector2.right / dampen);
                    //rb.AddForce(Vector2.right * dampen);
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, 0.4f);
    }
}