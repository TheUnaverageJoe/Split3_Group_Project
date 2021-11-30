using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport : MonoBehaviour
{
    public float teleportRadius = 5f;
    public float teleportDelay = 1f;
    public GameObject cursor_ok;
    public GameObject cursor_no;
    public GameObject cursor_check;
    private bool can_teleport = true;
    public float timer = 0;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        timer = teleportDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(paused){
            return;
        }
        
        timer += Time.deltaTime;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cursor_no_pos = cursor_no.gameObject.GetComponent<Transform>();
        var cursor_ok_pos = cursor_ok.gameObject.GetComponent<Transform>();
        var cursor_check_pos = cursor_check.gameObject.GetComponent<Transform>();

        Vector2 playerPos = this.gameObject.GetComponent<Transform>().position;
        float diff = Vector2.Distance(playerPos, mousePos);

        var col = cursor_ok.gameObject.GetComponent<BoxCollider2D>();
        //Debug.Log(mousePos);
        //Debug.Log(diff);

        if (diff <= teleportRadius && CursorCheck.GlobalVariables.can_teleport)
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

        cursor_check_pos.position = new Vector3(mousePos.x, mousePos.y, 0);
        //Debug.Log(cursor.position.x);
        //Debug.Log(cursor.position.y);

        if (Input.GetMouseButtonDown(0) && can_teleport && timer >= teleportDelay)
        {
            Transform player = this.gameObject.GetComponent<Transform>();
            player.position = mousePos + new Vector2(0, 0);
            timer = 0;
        }

    }


}
