using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerFlySpeed = 10f;
    [SerializeField] GameObject fireballs;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
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
            playerRigidbody.AddRelativeForce(playerFlySpeed * Time.deltaTime * Vector2.up);

            fireballs.SetActive(true);
            playerAnimator.SetBool("IsFlying", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            playerAnimator.SetBool("IsFlying", false);
            fireballs.SetActive(false);
        }
    }
}
