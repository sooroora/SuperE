using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private float flapForce = 10f;
    public bool isFlap = false;
    private Rigidbody2D _rigidbody;

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
            isFlap = true;
            _rigidbody.velocity = Vector3.up * flapForce;
        }
    }
    private void FixedUpdate()
    {
        
        //Vector3 velocity = _rigidbody.velocity;
        //if (isFlap)
        //{
        //    velocity.y += flapForce;
        //    isFlap = false;
        //}
        //_rigidbody.AddForce(velocity , ForceMode2D.Impulse);
        
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
