using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag==PreDefines.PLAYER_TAG)
        {
            //damage
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
        Destroy(gameObject);
    }
}
