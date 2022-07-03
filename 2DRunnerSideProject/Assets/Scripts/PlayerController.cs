using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float playerFlySpeed = 10f;

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();        
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddRelativeForce(Vector2.up * playerFlySpeed * Time.deltaTime);
            Debug.Log("asd");
        }
    }
}
