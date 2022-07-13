using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;

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
        lives = startLives;
        gameOverMenu.SetActive(false);

        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
            StartCoroutine(StartGameOverSequence());
        }
    }

    IEnumerator StartGameOverSequence()
    {
        DisableControllers();
        ThrowPlayer();
        DisableParallaxEffect();

        yield return new WaitForSeconds(1f);

        gameOverMenu.SetActive(true);

    }

    private void DisableParallaxEffect()
    {
        foreach (ParallaxScroller parallaxScroller in parallaxScrollers)
        {
            GameManager.instance.isDead = true;
        }
    }

    private void ThrowPlayer()
    {
        rb.velocity = (2 * Vector2.up + Vector2.left) * throwPow;

        Quaternion mainRot = transform.rotation;
        Quaternion deathRot = Quaternion.Euler(0f, 0f, throwRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, deathRot, 1f);
    }

    private void DisableControllers()
    {
        GetComponent<PlayerController>().enabled = false;
        FindObjectOfType<NodeSpawner>().enabled = false;
    }
}