using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneBoss : MonoBehaviour
{
    public GameObject stone;
    public Transform attackPoint;
    private Animator anim;
    public int health = 10;
    private bool canDamage=true;
    private string COR_NAME = "PlayAttack";
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(COR_NAME);
    }
    void BackToIdle()
    {
        anim.Play("StoneBossIdle");
    }
    void Attack()
    {
        GameObject obj=Instantiate(stone, attackPoint.position,Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -800f), 0f));
    }
    IEnumerator PlayAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.Play("StoneBossAttack");
        StartCoroutine(PlayAttack());
    }
    IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        GameObject.Find("Prompt").SetActive(true);
        GameObject.Find("Prompt").GetComponent<Text>().text = "CONGRATULATIONS!!!\nLEVEL PASSED";
        GameObject.Find("PauseB").SetActive(false);
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == PreDefines.BULLET_TAG)
        {
            if (canDamage)
            {
                health--;
                Debug.Log("hhh" + health);
                if (health == 0)
                {
                    StopCoroutine(COR_NAME);
                    anim.Play("StoneBossDead");
                    StartCoroutine(End());
                }
                else
                {
                    canDamage = false;
                    StartCoroutine(DamageWait());
                }
            }
        }

        if (other.gameObject.tag == PreDefines.PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
