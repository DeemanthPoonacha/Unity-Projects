using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<BulletFire>().Speed *= transform.localScale.x;
        }
    }
}
