using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport : MonoBehaviour
{

    public float teleportRadius = 5;
    public GameObject cursor_ok;
    public GameObject cursor_no;
    Vector3 diff;
    bool can_teleport;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cursor_no_pos = cursor_no.gameObject.GetComponent<Transform>();
        var cursor_ok_pos = cursor_ok.gameObject.GetComponent<Transform>();

        Vector3 playerPos = this.gameObject.GetComponent<Transform>().position;
        float diff = Vector3.Distance(playerPos, mousePos) - 10;

        //Debug.Log(diff);

        if (diff < teleportRadius)
        {
            cursor_ok.SetActive(true);
            cursor_no.SetActive(false);
            can_teleport = true;
        }
        
        else
        {
            cursor_ok.SetActive(false);
            cursor_no.SetActive(true);
            can_teleport = false;
        }

        if (cursor_no.activeSelf)
        {
            cursor_no_pos.position = new Vector3(mousePos.x, mousePos.y, -1);
        }
        else if (cursor_ok.activeSelf)
        {
            cursor_ok_pos.position = new Vector3(mousePos.x, mousePos.y, -1);
        }
        //Debug.Log(cursor.position.x);
        //Debug.Log(cursor.position.y);

        if (Input.GetMouseButtonDown(0) && can_teleport)
        {
            Transform player = this.gameObject.GetComponent<Transform>();
            player.position = mousePos + new Vector3(0, 0, 1);
        }

    }
}
