using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private string COR_NAME = "Jump";
    private string dir="L";
    private int jumpedTimes;
    private bool isAlive = true;
    private bool aniFinished = false;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(COR_NAME);
    }

    // void update()
    // {
    //     if(Physics2D.OverlapCircle())
    // }

    private void LateUpdate() {
        if(isAlive)
        {
            if (aniFinished)
            {
                StartCoroutine(COR_NAME);
                aniFinished = false;
            }
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        anim.Play("Jump"+dir);
        jumpedTimes++;
        // StartCoroutine(COR_NAME);
    }
    // Update is called once per frame
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    void AniFinished()
    {
        aniFinished = true;
        anim.Play("Idle"+dir);
        transform.parent.position = transform.position;
        transform.localPosition = Vector3.zero;
        if (jumpedTimes==3)
        {
            dir = (dir == "L")? "R" : "L";
            jumpedTimes = 0;
        }
        // dir=Mathf.RoundToInt(Random.Range(0f, 1f));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == PreDefines.BULLET_TAG)
        {
            isAlive = false;
            anim.Play("Dead");
            StopCoroutine(COR_NAME);
            StartCoroutine("Dead");
        }

        if (other.gameObject.tag == PreDefines.PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }
    
}
