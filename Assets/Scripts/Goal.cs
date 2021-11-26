using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Victory!");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Victory!");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
    }
}
