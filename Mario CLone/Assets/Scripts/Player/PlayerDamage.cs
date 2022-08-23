using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    private Text lifeText;
    private bool canDamage=true;

    public int lifeCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeText.text = "X " + lifeCount;
    }

    public void DealDamage()
    {
        if(canDamage)
        {
            lifeCount--;
            if (lifeCount > 0)
            {
                lifeText.text = "X " + lifeCount;
                // GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r,GetComponent<Renderer>().material.color.g,GetComponent<Renderer>().material.color.b,10);
            }
            else if(lifeCount==0)
            {
                lifeText.text = "X " + lifeCount;
                //restart
                Time.timeScale = 0;
                StartCoroutine(Reload());
            }
            canDamage = false;
            StartCoroutine(DamageWait());
        }
    }

    IEnumerator DamageWait()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
        // GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 10);
        // GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("GamePlayScene");
        Time.timeScale = 1;
    }
}
