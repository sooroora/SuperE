using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float flapForce = 20f;
    public bool isFlap = false;
    private Rigidbody2D _rigidbody;
    private int jumpCount = 2;
    private CapsuleCollider2D PlayerSize;
    private Vector3 ori;
    private Vector3 slide;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSize = GetComponent<CapsuleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ori = PlayerSize.size;
        slide = PlayerSize.size * 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (jumpCount == 2)
            {
                animator.SetBool("IsJump", true);
                _rigidbody.velocity = Vector3.up * flapForce;
                jumpCount--;
            }
            else if (jumpCount == 1)
            {
                animator.SetBool("IsDubleJump", true);
                _rigidbody.velocity = Vector3.up * (flapForce * 0.8f);
                jumpCount--;
            }
            else return;
            
        }
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("IsSliding", true);
            PlayerSize.size = slide;
            PlayerSize.offset = new Vector2(0, -(ori.y - slide.y) / 2f);
            
        }
        else 
        {
            animator.SetBool("IsSliding", false);
            PlayerSize.size = ori;
            PlayerSize.offset = Vector2.zero;
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
            animator.SetBool("IsDubleJump", false);
            animator.SetBool("IsJump", false);
            jumpCount = 2;
        }

    }
}
