using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private CapsuleCollider2D capsuleCollider;

    GameObject[] nodes;
    private bool isConnected = false;
    private float minDistance = Mathf.Infinity;
    private GameObject closestNode;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        SetLineRenderer();

    }

    private void SetLineRenderer()
    {
        if (!isConnected)
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");

            foreach (GameObject node in nodes)
            {
                if (Vector3.Distance(this.transform.position, node.transform.position) <= minDistance)
                {
                    minDistance = Vector3.Distance(this.transform.position, node.transform.position);
                    closestNode = node;
                }
            }
        }

        if (closestNode != null)
        {
            isConnected = true;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, closestNode.transform.position);
            lineRenderer.SetPosition(1, this.transform.position);

            SetCollider();
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void SetCollider()
    {
        Vector2 sides = new Vector2(closestNode.transform.position.x - this.transform.position.x, closestNode.transform.position.y - this.transform.position.y);
        float colliderLength = Mathf.Sqrt(Mathf.Pow(sides.x, 2) + Mathf.Pow(sides.y, 2)) + this.transform.localScale.x;

        Vector2 colliderSize = new Vector2(this.transform.localScale.x, colliderLength);
        Vector2 colldierOffset = new Vector2(0f, (colliderLength - this.transform.localScale.y) / 2);
        float rotationZ = Mathf.Atan2(sides.y, sides.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
        capsuleCollider.offset = colldierOffset;
        capsuleCollider.size = colliderSize;
    }
}
