using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Victory!");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited");
    }
}
