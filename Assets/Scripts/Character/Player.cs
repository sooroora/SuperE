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
        if (collision.CompareTag("Obstacle")) //플레이어가 충돌시 벽 인지 체크
        {
            GameManager.Instance.Crash();
        }
        //else 아이템 사용 
        //{
        //    
        //    
        //}
    }
}
