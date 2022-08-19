using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private CapsuleCollider2D capsuleCollider;

    GameObject[] nodes;
    private GameObject closestNode;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        SetLineRenderer();
    }

    private void SetLineRenderer()
    {
        if (ReferenceEquals(closestNode, null))
        {
            nodes = GameObject.FindGameObjectsWithTag("Node");

            float minDistance = Mathf.Infinity;
            closestNode = null;

            foreach (GameObject node in nodes)
            {
                float dis = Vector3.Distance(transform.position, node.transform.position);
                if (dis <= minDistance)
                {
                    minDistance = dis;
                    closestNode = node;
                }
            }
        }

        if (closestNode != null)
        {
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, closestNode.transform.position);

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
        float rotationZ = Mathf.Atan2(sides.y, sides.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        capsuleCollider.offset = colldierOffset;
        capsuleCollider.size = colliderSize;
    }
}
