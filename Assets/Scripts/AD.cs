using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    private float startT;
    public float timer = 5;
    public float location;
    public GameObject player;
    private GameObject currentObj;
    private SpriteRenderer srcurrentObj;

    float newY;
    // Start is called before the first frame update
    void Start()
    {
        currentObj = this.gameObject;
        srcurrentObj = currentObj.GetComponent<SpriteRenderer>();

        startT = Time.time;

        srcurrentObj.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startT > timer){
            srcurrentObj.color = new Color(255, 255, 255, 255);
        }
    }
}
