using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float flapForce = 20f; //점프력
    public bool isFlap = false; //점프유무 확인
    protected Rigidbody2D _rigidbody; // 물리엔진 변수값
    protected int jumpCount = 2; // 점프횟수
    protected CapsuleCollider2D PlayerSize; // 캐릭터 사이즈 변수
    protected Vector3 ori; // 캐릭터 사이즈를 저장하기 위한 변수
    protected Vector3 slide;// 캐릭터가 슬라이드시 사이즈를 줄이기 위한 변수
    protected Animator animator; // 애니메이터 변수
    protected bool isInvincible = false; //충돌무적

    // Start is called before the first frame update
    protected virtual void Start()
    {
        PlayerSize = GetComponent<CapsuleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ori = PlayerSize.size; //플레이어의 원래 사이즈를 담음
        slide = PlayerSize.size * 0.5f; // 플레이어 사이즈를 절반으로 줄여서 담음
    }

    // Update is called once per frame
    protected virtual void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.LeftAlt)) //alt 키 입력시 1번은 점프 2번은 더블점프 
        {
            if (jumpCount >= 2) //점프
            {
                animator.SetBool("IsJump", true);
                _rigidbody.velocity = Vector3.up * flapForce;
                jumpCount--;
            }
            else if (jumpCount == 1) //더블점프
            {
                animator.SetBool("IsDubleJump", true);
                _rigidbody.velocity = Vector3.up * (flapForce * 0.8f);
                jumpCount--;
            }
            else return;
        }
        if (Input.GetKey(KeyCode.Z)) //슬라이딩 유무 
        {
            if (animator.GetBool("IsJump") || animator.GetBool("IsDubleJump"))
            {
                return;
            }
            else
            {
                animator.SetBool("IsSliding", true);
                PlayerSize.size = slide;
            }
        }
        else 
        {

            animator.SetBool("IsSliding", false);
            PlayerSize.size = ori;
        }
        if (!animator.GetBool("Hited"))
        {
            isInvincible = false;
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!animator.GetBool("Hited"))
        {
            if (collision.GetComponent<Obstacle>() != null) //플레이어가 충돌시 벽 인지 체크
            {
                isInvincible = true;
                animator.SetBool("Hited", true);
                GameManager.Instance.Crash();
            }
        }
        //else if()//아이템 사용
        else
        {
            return;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Floor")) //플레이어가 충돌한것이 Floor인지 확인
        {
            animator.SetBool("IsDubleJump", false); // 더블점프 애니메이터 종료
            animator.SetBool("IsJump", false); // 점프 애니메이터 종료
            jumpCount = 2; // 점프를 했다면 점프횟수를 돌려주기 위한 변수
        }
    }
    public void StarpedAnimataion()
    {
        animator.SetBool("Hited",false);
    }
}
