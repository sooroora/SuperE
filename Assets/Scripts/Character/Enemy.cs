using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Character
{
    protected Transform EnemyTransform; // 적의 현재위치를 저장하기 위한 변수
    
    protected Vector3 Transform = Vector3.zero; //위치값 변경을 위한 변수
    protected Vector3 speed = Vector3.zero; //이속을 위한 변수
    
    

    

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
    protected void Move() // 충돌시 플레이어와의 거리를 줄이기 위한 로직
    {

        if (crash) 
        {
            EnemyTransform.position = Vector3.SmoothDamp(transform.position,move,ref speed,1.0f);
             
            if (Vector3.Distance(EnemyTransform.position, move) < 0.1f)
            {
                crash = false;
            }
        }
    }
     
}
