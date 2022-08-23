using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D myBody;
    private Animator anim;
    private Transform groundCheck;
    [SerializeField]
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isJumping;
    public int jumpPower=5;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }
    void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log(h);

        myBody.velocity = new Vector2(h * speed, myBody.velocity.y);
        if(h!=0) ChangeDirection(h);
        anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
    }

    void ChangeDirection(float h)
    {
        Vector3 Temp = transform.localScale;
        Temp.x = h;//new Vector3(h, transform.localScale.y, transform.localScale.z);
        transform.localScale = Temp;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="ground")
        {
            // Debug.Log(other);
        }
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
        if (isGrounded)
        {
            if (isJumping)
            {
                isJumping = false;
                anim.SetBool("Jump", isJumping);
            }
        }
    }

    void PlayerJump()
    {
        if(isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isJumping = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                anim.SetBool("Jump", isJumping);
            }
        }
    }
}
