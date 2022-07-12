using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    private float length;
    private Vector2 startPos;
    private Camera mainCam;
    [SerializeField] float parallaxEffect;
    [SerializeField] Transform turnPoint;
    float reduceAmountPerTime = .000000001f;

    private Material myMat;

    private void Start() {
        mainCam = Camera.main;
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        myMat = GetComponent<Renderer>().material;
    }

    private void FixedUpdate() {
        if(!GameManager.instance.isDead)
        {
            transform.Translate(Vector2.left * parallaxEffect * Time.deltaTime);

            if(turnPoint.position.x <= mainCam.transform.position.x)
            {
                transform.position = startPos;
            }
        }

        if(GameManager.instance.isDead)
        {
            DeathSequence();
        }
    }

    void DeathSequence()
    {
        parallaxEffect -= reduceAmountPerTime * (parallaxEffect / 4) * Time.deltaTime;
    }
}
