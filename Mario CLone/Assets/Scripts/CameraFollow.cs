using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Bounds camBounds;

    public Transform target;

    public Vector3 lastTargetPos;

    public float offSetz;

    public bool followPlayer;

    public Vector3 curVelocity;

    public float camSpeed = 0.3f;

    void Awake()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.size = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, 15f);
        camBounds = col.bounds;
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(PreDefines.PLAYER_TAG).transform;
        lastTargetPos = target.position;
        offSetz = (transform.position - target.position).z;
        followPlayer = true;
    }

    void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offSetz;
            if (aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCamPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref curVelocity, camSpeed);
                transform.position = new Vector3(newCamPos.x, transform.position.y, newCamPos.z);
                lastTargetPos = transform.position;
            }
            else if (aheadTargetPos.x < (transform.position.x-5f))
            {
                Vector3 newCamPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref curVelocity, camSpeed);
                transform.position = new Vector3(newCamPos.x+5f, transform.position.y, newCamPos.z);
                lastTargetPos = transform.position;
            }
            // Vector3 behindTargetPos = target.position + Vector3.forward * offSetz;
            // if ((behindTargetPos.x - 3f) < transform.position.x)
            // {
            //     Vector3 newCamPos = Vector3.SmoothDamp(transform.position, behindTargetPos, ref curVelocity, camSpeed);
            //     transform.position = new Vector3(newCamPos.x, transform.position.y, newCamPos.z);
            //     lastTargetPos = transform.position;
            // }
        }
    }
}
