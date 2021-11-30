using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCheck : MonoBehaviour
{
    public static class GlobalVariables
    {
        public static bool can_teleport = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GlobalVariables.can_teleport = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GlobalVariables.can_teleport = true;
    }
}