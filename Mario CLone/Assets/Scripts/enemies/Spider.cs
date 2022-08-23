using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    private Vector3 originPos;
    public float moveRange = 6f;
    // private int direction = -1;
    private Vector3 moveDirection = Vector3.down;
    private bool isAlive = true;
    private string COR_NAME = "ChangeDir";

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originPos = transform.position;
        anim.SetBool("Alive", true);
        StartCoroutine(COR_NAME);
    }
    void Update()
    {
        if (isAlive)
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(moveDirection * Time.smoothDeltaTime);
        // Vector3 temp = transform.position;
        // temp.y += direction * speed * Time.deltaTime;
        // transform.position = temp;
        // ChangeDir();
    }

    IEnumerator ChangeDir()
    {
        // if (transform.position.y >= (originPos.y + moveRange) || transform.position.y <= (originPos.y - moveRange))
        // {
        //     direction = (direction == 1) ? -1 : 1;
        // }
        // Vector3 temp = transform.localScale;
        // temp.x = -direction;
        // transform.localScale = temp;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        Change();

        StartCoroutine(COR_NAME);
    }

    private void Change()
    {
        moveDirection = (moveDirection == Vector3.down) ? Vector3.up : Vector3.down;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == PreDefines.BULLET_TAG)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            myBody.bodyType = RigidbodyType2D.Dynamic;
            isAlive = false;
            anim.SetBool("Alive", isAlive);

            StartCoroutine(Dead());
            StopCoroutine(COR_NAME);
        }

        if (other.gameObject.tag == PreDefines.GROUND_TAG)
        {
            Change();
        }
        if (other.gameObject.tag == PreDefines.PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
