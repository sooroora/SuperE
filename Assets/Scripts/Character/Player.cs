using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Obstacle") //플레이어가 충돌시 벽 인지 체크
        {
            move = transform.position + right;
            crash = true; //만약 벽이 맞다면 Enemy 스크립트에 있는 Move를 켜주기 위한 bool값
        }
        else
        {

        }
    }
}
