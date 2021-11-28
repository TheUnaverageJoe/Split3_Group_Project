using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    float startT;
    float startX;
    float startY;
    bool canMove;
    bool canJump;
    GameObject circle;
    GameObject ad;
    SpriteRenderer srad;
    GameObject spacebar;
    SpriteRenderer srspacebar;

    float newY;
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.Find("Circle");

        ad = GameObject.Find("ad");
        srad = ad.GetComponent<SpriteRenderer>();

        spacebar = GameObject.Find("spacebar");
        srspacebar = spacebar.GetComponent<SpriteRenderer>();

        startT = Time.time;
        startX = circle.transform.position.x;
        canMove = false;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove && Time.time - startT > 5){
            float newX = circle.transform.position.x;
            if(newX == startX)
            {
                srad.color = new Color(255, 255, 255, 255);
            }
            startY = circle.transform.position.y;
            canMove = true;
        }
        if(!canJump && Time.time - startT > 12)
        {
            float newY = circle.transform.position.y;
            if(newY == startY)
            {
                srspacebar.color = new Color(255, 255, 255, 255);
            }
            canJump = true;
        }
    }
}
