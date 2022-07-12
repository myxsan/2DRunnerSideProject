using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D rb;

    ParallaxScroller[] parallaxScrollers;

    [SerializeField] AnimationClip damageAnimation;
    [SerializeField] int startLives = 3;
    [SerializeField] float throwPow = 100f;
    [SerializeField] [Range(0f, 90f)] float throwRot;
    int lives;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lives = startLives;

        parallaxScrollers = FindObjectsOfType<ParallaxScroller>();
    }

    public IEnumerator DecreaseLives()
    {
        lives--;

        if(lives > 0)
        {
            playerAnimator.SetBool("HasDamaged", true);

            yield return new WaitForSeconds(damageAnimation.length);

            playerAnimator.SetBool("HasDamaged", false);
        }else
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        FindObjectOfType<NodeSpawner>().enabled = false;

        rb.velocity = (2 * Vector2.up + Vector2.left) * throwPow;
        
        Quaternion mainRot = transform.rotation;
        Quaternion deathRot = Quaternion.Euler(0f, 0f, throwRot);
        transform.rotation = Quaternion.Slerp(transform.rotation,deathRot, 1f);

        foreach(ParallaxScroller parallaxScroller in parallaxScrollers)
        {
            GameManager.instance.isDead = true;
        }
    }
}