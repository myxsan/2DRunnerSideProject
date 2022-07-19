using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [SerializeField] float parallaxEffect;
    [SerializeField] float reduceAmountPerTime = .1f;
    [SerializeField] bool isFullImage = true;

    [Tooltip("Leave it blank if it is full image")]
    [SerializeField] Transform turnPoint;

    private float length;
    private Vector2 startPos;
    private Material material;

    private void Start()
    {
        startPos = transform.position;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        material = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if (isFullImage) FullImageParallaxScroller();
        else if (!isFullImage) NonFullImageParallaxScroll();

        if (GameManager.instance.isDead)
        {
            DeathSequence();
        }
    }

    private void FullImageParallaxScroller()
    {
        material.mainTextureOffset += new Vector2(parallaxEffect * Time.deltaTime, 0f);
    }

    private void NonFullImageParallaxScroll()
    {
        transform.Translate(Vector2.left * parallaxEffect * Time.deltaTime, Space.World);

        if (turnPoint.position.x <= Camera.main.transform.position.x)
        {
            transform.position = startPos;
        }
    }

    void DeathSequence()
    {
        if (isFullImage)
        {
            parallaxEffect -= reduceAmountPerTime * 0.1f * Time.deltaTime;
        }
        else
        {
            parallaxEffect -= reduceAmountPerTime * Time.deltaTime;
        }

        if (parallaxEffect <= 0)
        {
            parallaxEffect = 0;
            this.enabled = false;
        }
    }
}
