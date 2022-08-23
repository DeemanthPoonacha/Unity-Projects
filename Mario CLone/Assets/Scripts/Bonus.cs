using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Transform bottomCol; 
    private Animator anim;
    private bool startAnimate=false;
    private bool canAnimate = true;
    private Vector3 originPos;
    private Vector3 animPos;
    Vector3 moveDIr = Vector3.up;
    public LayerMask playerLayer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        originPos = transform.position;
        animPos = transform.position;
        animPos.y += 0.15f;
    }

    void Update()
    {
        if(canAnimate)
        {
            if (Physics2D.Raycast(bottomCol.position, Vector2.down, 0.1f, playerLayer))
            {
                startAnimate = true;
                canAnimate = false;
                GameObject.FindGameObjectWithTag(PreDefines.PLAYER_TAG).GetComponent<Score>().ScoreUpdate(1);
                Debug.Log("scs");
            }
        }
        Move();
    }

    private void Move()
    {
        if(startAnimate)
        {
            transform.Translate(moveDIr * Time.smoothDeltaTime);

            if (transform.position.y > animPos.y)
            {
                moveDIr = Vector3.down;
            }
            else if(transform.position.y < originPos.y)
            {
                startAnimate = false;
                anim.Play("Idle");
            }
        }
    }
}
