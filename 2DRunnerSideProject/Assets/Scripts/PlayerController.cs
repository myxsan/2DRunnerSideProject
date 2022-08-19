using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerFlySpeed = 10f;
    [SerializeField] GameObject fireballs;

    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    private Animator playerAnimator;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();

        fireballs.SetActive(false);
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            playerRigidbody.AddRelativeForce(Vector2.up * playerFlySpeed * Time.deltaTime);

            fireballs.SetActive(true);
            playerAnimator.SetBool("IsFlying", true);
        }
        else if ((!Input.GetKey(KeyCode.Space) || !Input.GetMouseButton(0)) && !HasVerticleSpeed())
        {
            playerAnimator.SetBool("IsFlying", false);
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            fireballs.SetActive(false);
        }
    }

    private bool HasVerticleSpeed()
    {
        if (playerRigidbody.velocity.y < 0.0001f && playerRigidbody.velocity.y > -0.0001f && transform.position.y < -4.5)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
