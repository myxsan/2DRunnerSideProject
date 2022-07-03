using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private LineRenderer lineRenderer;

    GameObject[] nodes;
    private bool isConnected = false;
    private float minDistance = Mathf.Infinity;
    private GameObject closestNode;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        if(!isConnected)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");

            foreach(GameObject node in nodes)
            {
                if(Vector3.Distance(this.transform.position, node.transform.position) <= minDistance)
                {
                    minDistance = Vector3.Distance(this.transform.position, node.transform.position);
                    closestNode = node;
                }
            }
        }

        if(closestNode != null)
        {
            isConnected = true;
            lineRenderer.SetPosition(0, closestNode.transform.position);
            lineRenderer.SetPosition(1, this.transform.position);
        }

    }
}
