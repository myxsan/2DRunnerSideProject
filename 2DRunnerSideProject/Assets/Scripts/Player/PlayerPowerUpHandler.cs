using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IPowerUp>() != null)
        {
            collision.GetComponent<IPowerUp>().ApplyPowerUp();
        }
    }
}
