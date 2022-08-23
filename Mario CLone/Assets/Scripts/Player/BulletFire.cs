using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    private float speed = 10f;
    private bool canMove=true;
    private Animator anim;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }


    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start() {
        StartCoroutine(DestryBullet(5f));
    }
    void Update() {
        if(canMove)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 temp = transform.localPosition;
        temp.x += speed * Time.deltaTime;
        transform.localPosition = temp;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Hit(other.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Hit(other.gameObject);
    }

    private void Hit(GameObject other)
    {
        // if(other.gameObject.tag==PreDefines.SNAIL_TAG||other.gameObject.tag == PreDefines.BEETLE_TAG)
        if (other.layer == PreDefines.ENEMY_LAYER)
        {
            Debug.Log("exp");
            anim.Play("Explode");
            StartCoroutine(DestryBullet(0.1f));
            canMove = false;
        }
        if ( other.tag == PreDefines.GROUND_TAG)
        {
            anim.Play("Explode");
            StartCoroutine(DestryBullet(0.1f));
            canMove = false;
        }
    }

    IEnumerator DestryBullet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
