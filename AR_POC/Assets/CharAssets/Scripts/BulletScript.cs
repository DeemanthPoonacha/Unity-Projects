using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody myBody;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        Invoke("DeActivate",3f);
        MoveBullet(200f);
    }

    public void MoveBullet(float speed)
    {
        myBody.AddForce(transform.forward.normalized*speed);
    }

    void DeActivate()
    {
        Destroy(gameObject);
    }
}
