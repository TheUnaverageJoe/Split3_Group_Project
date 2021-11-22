using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    Rigidbody2D rb;
    int jumpStrength = 10;
    bool canJump = false;
    bool canMove = false;
    int moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && canJump){
            rb.velocity += Vector2.up*jumpStrength;
            canJump = false;
            canMove = false;
        }

        if(canMove){
            if(Input.GetAxis("Horizontal") < 0){
                rb.velocity = Vector2.zero;
                rb.velocity += Vector2.left*moveSpeed;
            }else if(Input.GetAxis("Horizontal") > 0){
                rb.velocity = Vector2.zero;
                rb.velocity += Vector2.right*moveSpeed;
            }else{
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        canMove = true;
    }
}
