using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : Character
{
    protected Transform EnemyTransform;
    protected Vector3 move = Vector3.zero;
    protected Vector3 Transform = Vector3.zero;
    protected Vector3 right = Vector3.right;
    protected Vector3 left = Vector3.left;
    protected Vector3 speed = Vector3.zero;
    
    

    

    private void Awake()
    {
        EnemyTransform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    protected void Move()
    {
        if (crash)
        {

            move = Vector3.SmoothDamp(EnemyTransform.position,EnemyTransform.position + right,ref speed,1.0f);
            transform.position = move;
            if (EnemyTransform.position == EnemyTransform.position + right)
            {
                crash = false;
            }
        }
    }
     
}
