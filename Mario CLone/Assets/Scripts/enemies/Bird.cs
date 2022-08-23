using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public GameObject stone;
    public LayerMask playerLayer;
    private Vector3 originPos;
    public float flyRange=6f;
    private int direction = -1;
    private bool hasAttacked = false;
    private bool isAlive = true;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originPos = transform.position;
        anim.SetBool("Alive", true);
    }
    void Update()
    {
        if (isAlive)
        {
            Move();
            Attack();
        }
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += direction * speed * Time.deltaTime;
        transform.position = temp;
        ChangeDir();
    }

    void ChangeDir()
    {
        if (transform.position.x>=(originPos.x+flyRange)||transform.position.x <= (originPos.x - flyRange))
        {
            direction = (direction == 1) ? -1 : 1;
        }
        Vector3 temp = transform.localScale;
        temp.x = -direction;
        transform.localScale = temp;
    }

    void Attack()
    {
        if(!hasAttacked)
        {
            if(Physics2D.Raycast(transform.position,Vector2.down,Mathf.Infinity,playerLayer))
            {
                Instantiate(stone, transform.position + Vector3.down, Quaternion.identity);
                hasAttacked = true;
                anim.SetBool("Attacked", hasAttacked);
            }
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other) {        
        if(other.gameObject.tag==PreDefines.BULLET_TAG)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            isAlive = false;
            anim.SetBool("Alive", isAlive);

            StartCoroutine(Dead());
        }
        if (other.gameObject.tag == PreDefines.PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }

    }
}
