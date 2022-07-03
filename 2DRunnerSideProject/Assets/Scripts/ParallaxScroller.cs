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

    private Material myMat;

    private void Start() {
        mainCam = Camera.main;
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        myMat = GetComponent<Renderer>().material;
    }

    private void FixedUpdate() {
        transform.Translate(Vector2.left * parallaxEffect);

        if(turnPoint.position.x <= mainCam.transform.position.x)
        {
            transform.position = startPos;
        }

    }

    // private void Update() {
    //     myMat.mainTextureOffset += parallaxEffect * Time.deltaTime;
    // }
}
