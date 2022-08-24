using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UI;
#endif
public class CharMovement : MonoBehaviour
{
    public bool canMove = true;
    private bool isMoving = false;
    private bool action = false;
    // public bool facingLeft = false;
    public float speed = 1;

    // public float rotAngle = 30;
    private Rigidbody myBody;
    private Animator anim;

    public bool canShoot=false;
#region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(CharMovement))]
    public class SootActionClass : Editor 
    {
        public override void OnInspectorGUI() 
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            CharMovement mov=(CharMovement)target;  
            if (mov.canShoot)
            {
                EditorGUILayout.LabelField("Shoot Action");  
                // GameObject bf=mov.BulletPref;
                // mov.BulletPref=new GameObject();
                mov.BulletPref=(GameObject)EditorGUILayout.ObjectField("Bullet Prefab",mov.BulletPref,typeof(GameObject),true);
                mov.BulletFiringPoint=(Transform)EditorGUILayout.ObjectField("Bullet Firing Point",mov.BulletFiringPoint,typeof(Transform),true);
                mov.shootFX=(ParticleSystem)EditorGUILayout.ObjectField("ShootFX",mov.shootFX,typeof(ParticleSystem),true);
                // mov.shootButton=(Button)EditorGUILayout.ObjectField("Shoot Button",mov.shootButton,typeof(Button),true);
                // mov.speed=EditorGUILayout.FloatField(mov.speed);
            }
        }
    }
#endif
#endregion 
    // public class SootActionClass
    // public SerializedProperty bulletc;
    [HideInInspector]
    public GameObject BulletPref;
    [HideInInspector]
    public Transform BulletFiringPoint;
    [HideInInspector]
    public ParticleSystem shootFX;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        // shootButton.onClick.AddListener(Shoot);
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
        Action();
    }
    bool actionPressed;

    public void Action()
    {
        GetComponent<PlayerInput>().actions["Action"].started += ctx => actionPressed = true;
        if(actionPressed)
        {
            GetComponent<PlayerInput>().actions["Action"].canceled += ctx => actionPressed = false;
            StartAction();
        }
    }

    private void Move()
    {
        Vector2 input = GetComponent<PlayerInput>().actions["Movements"].ReadValue<Vector2>();
        float h = input.x;
        float v = input.y;

        // float v = Input.GetAxis("Vertical");
        // float h = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector3(h, 0, v) * speed;
        if (h != 0 || v != 0)
        {
            Vector3 eulers = new Vector3(transform.eulerAngles.x, Mathf.Atan2(h, v) * Mathf.Rad2Deg, transform.eulerAngles.z);
            transform.eulerAngles = eulers;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        anim.SetBool("Walk", isMoving);
        anim.SetBool("Idle", !isMoving);
    }

    public void StartAction()
    {
        action = true;
        anim.SetBool("Action", action);
        StartCoroutine(EndAction());
        if(canShoot)
        {Shoot();}
    }
    IEnumerator EndAction()
    {
        yield return new WaitForSeconds(0.3f);
        action = false;
        anim.SetBool("Action", action);
    }
    public void Shoot()
    {
        shootFX.Play();
        GameObject bullet = Instantiate(BulletPref,BulletFiringPoint.position,BulletFiringPoint.rotation);
        // bullet.transform.parent=BulletFiringPoint;
        // bullet.GetComponent<BulletScript>().MoveBullet(5000f);
    }

}
