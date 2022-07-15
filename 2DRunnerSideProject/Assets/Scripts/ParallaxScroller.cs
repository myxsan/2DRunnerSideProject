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
    private Camera mainCam;
    private Material myMat;

    private void Start() {
        mainCam = Camera.main;
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        myMat = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if(isFullImage) FullImageParallaxScroller();
        else if(!isFullImage)NonFullImageParallaxScroll();

        if (GameManager.instance.isDead)
        {
            DeathSequence();
        }
    }

    private void FullImageParallaxScroller()
    {
        myMat.mainTextureOffset += new Vector2(parallaxEffect * Time.deltaTime, 0f);
    }

    private void NonFullImageParallaxScroll()
    {
        transform.Translate(Vector2.left * parallaxEffect * Time.deltaTime);

        if (turnPoint.position.x <= mainCam.transform.position.x)
        {
            transform.position = startPos;
        }
    }

    void DeathSequence()
    {
        if(isFullImage)
        {
            parallaxEffect -= reduceAmountPerTime * 0.1f * Time.deltaTime;
        }else
        {
            parallaxEffect -= reduceAmountPerTime * Time.deltaTime;
        }

        if(parallaxEffect <= 0) 
        {
            this.enabled = false;
            return;
        } 
    }
}
