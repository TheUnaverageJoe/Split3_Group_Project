using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TeleportVisual : MonoBehaviour
{
    public int vertexCount = 100; // 4 vertices == square
    public float lineWidth = 0.2f;
    public float radius = 5;

    public GameObject player;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        radius = player.GetComponent<Teleport>().teleportRadius;
    }

    private void SetupCircle(float x, float y)
    {
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount+1;
        for (int i=0; i<lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(x + radius * Mathf.Cos(theta),y + radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

    void Update(){
        var pos = player.gameObject.transform.position;
        SetupCircle(pos.x,pos.y);
    }
}