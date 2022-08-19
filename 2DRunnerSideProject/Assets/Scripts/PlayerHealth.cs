using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("On Hit References")]
    [SerializeField] Transform livesParent;
    [SerializeField] AnimationClip damageAnimation;

    [Header("Player Stats")]
    [SerializeField] int startLives = 3;

    [Header("Death Sequence")]
    [SerializeField] float throwPow = 100f;
    [SerializeField][Range(0f, 90f)] float throwRot;

    private bool damageTaken = false;
    private float damageCountDown = 0;

    Animator playerAnimator;
    Rigidbody2D rb;

    ParallaxScroller[] parallaxScrollers;
    Image[] hearths;

    int lives;
    void Start()
    {
        lives = startLives;

        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!damageTaken) return;
        damageCountDown -= Time.deltaTime;

        if (damageCountDown > 0) return;
        damageTaken = false;
    }

    public IEnumerator DecreaseLives()
    {
        if (!damageTaken)
        {
            lives--;
            damageTaken = true;
            damageCountDown = 1;
        }

        if (lives >= 0)
        {
            DisableLiveAnim(livesParent.GetChild(lives).GetComponent<Image>());
        }

        if (lives > 0)
        {

            playerAnimator.SetBool("HasDamaged", true);

            yield return new WaitForSeconds(damageAnimation.length);

            playerAnimator.SetBool("HasDamaged", false);
        }
        else
        {
            StartCoroutine(StartGameOverSequence());
        }
    }

    IEnumerator StartGameOverSequence()
    {
        DisableControllers();
        DisablePlayUI();
        ThrowPlayer();
        DisableParallaxEffect();

        yield return new WaitForSeconds(1f);

        GameManager.instance.SetGameOverMenu(true);
    }

    private void DisableControllers()
    {
        GetComponent<PlayerController>().enabled = false;
        FindObjectOfType<NodeSpawner>().enabled = false;
    }

    private void DisablePlayUI()
    {
        GameManager.instance.playUI.SetActive(false);
    }

    private void ThrowPlayer()
    {
        rb.velocity = (2 * Vector2.up + Vector2.left) * throwPow;

        Quaternion mainRot = transform.rotation;
        Quaternion deathRot = Quaternion.Euler(0f, 0f, throwRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, deathRot, 1f);
    }

    private void DisableParallaxEffect()
    {
        parallaxScrollers = FindObjectsOfType<ParallaxScroller>();

        foreach (ParallaxScroller parallaxScroller in parallaxScrollers)
        {
            GameManager.instance.isDead = true;
        }
    }

    private void DisableLiveAnim(Image live)
    {
        live.GetComponent<Animator>().enabled = true;
    }
}