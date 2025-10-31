using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sura : Player
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) //플레이어가 충돌시 벽 인지 체크
        {
            
            int destroy = Random.Range(1, 11);
            Debug.Log(destroy);
            if (destroy <= 3)
            {
                GameObject.Destroy(collision.gameObject);
            }
            else
            {
                GameManager.Instance.Crash();
            }
                
        }
    }
}
