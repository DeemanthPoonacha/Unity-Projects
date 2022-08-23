using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public Transform groundCheck, rightCheck, leftCheck, topCheck;
    private int direction = -1;
    private bool stunned = false;
    public LayerMask playerLayer;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // groundCheck = transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftCheck.position, -direction * Vector2.left, 0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightCheck.position, -direction * Vector2.right, 0.1f, playerLayer);

        if (!stunned)
        {
            Move();
            if (leftHit || rightHit)
            {
                if (leftHit) Debug.Log("left");
                if (rightHit) Debug.Log("right");
                GameObject.FindWithTag(PreDefines.PLAYER_TAG).GetComponent<PlayerDamage>().DealDamage();
            }
            Collider2D topHit = Physics2D.OverlapCircle(topCheck.position, 0.2f, playerLayer);
            if (topHit)
            {
                topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 8f);
                stunned = true;
                anim.Play("Stunned");
                speed = 0;
            }
        }
        else
        {
            float dur = 3f;
            if (tag == PreDefines.SNAIL_TAG)
            {
                dur = 5f;
                if (leftHit || rightHit)
                {
                    myBody.velocity = leftHit ? (direction * Vector2.left) * 15f : (direction * Vector2.right) * 15f;
                }
            }
            if (tag == PreDefines.BEETLE_TAG)
            {
                dur = 0.2f;
            }
            Invoke("Dead", dur);
        }
    }
    
    void Dead()
    {
        Destroy(gameObject);
    }

    void Move()
    {
        myBody.velocity = new Vector2(direction * speed, 0);
        ChangeDir();
    }

    void ChangeDir()
    {
        if (!Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f))
        {
            direction = (direction == 1) ? -1 : 1;
        }
        Vector3 temp = transform.localScale;
        temp.x = -direction;
        transform.localScale = temp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == PreDefines.BULLET_TAG)
        {
            if(stunned)
            {
                Invoke("Dead", 0f);
            }
            stunned = true;
            speed = 0;
            anim.Play("Stunned");
            myBody.velocity = new Vector2(0, 0);
            if (tag == PreDefines.BEETLE_TAG)
            {
                Invoke("Dead", 0.4f);
            }

        }
    }
}
