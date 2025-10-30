using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float flapForce = 20f;
    public bool isFlap = false;
    private Rigidbody2D _rigidbody;
    private int jumpCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (jumpCount == 2)
            {
                _rigidbody.velocity = Vector3.up * flapForce;
                jumpCount--;
            }
            else if (jumpCount == 1)
            {
                _rigidbody.velocity = Vector3.up * (flapForce * 0.5f);
                jumpCount--;
            }
            else return;
            
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 2;
        }

    }
}
