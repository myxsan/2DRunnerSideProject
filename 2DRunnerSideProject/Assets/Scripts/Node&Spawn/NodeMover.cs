using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMover : MonoBehaviour
{
    [SerializeField] float pushSpeed = 10f;

    private void Update()
    {
        if (transform.position.x >= -50)
        {
            transform.Translate(Vector2.left * pushSpeed * Time.deltaTime, Space.World);
        }else
        {
            this.gameObject.SetActive(false);
        }
    }
}
