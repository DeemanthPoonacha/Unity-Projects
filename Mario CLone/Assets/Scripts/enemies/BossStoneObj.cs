using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStoneObj : MonoBehaviour
{
    void Start()
    {
        Invoke("SelfDestroy",4f);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag==PreDefines.PLAYER_TAG)
        {
            other.GetComponent<PlayerDamage>().DealDamage();
            SelfDestroy();
        }
    }
}
