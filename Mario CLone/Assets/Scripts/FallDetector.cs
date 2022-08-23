using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag==PreDefines.PLAYER_TAG)
        {
            other.gameObject.GetComponent<PlayerDamage>().DealDamage();
            Vector3 temp = other.gameObject.transform.position;
            temp.x -= 3;
            temp.y = 6;
            other.gameObject.transform.position = temp;
        }
    }
}
