using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaewoo : Player
{
    

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) //플레이어가 충돌한것이 Floor인지 확인
        {
            animator.SetBool("IsDubleJump", false); // 더블점프 애니메이터 종료
            animator.SetBool("IsJump", false); // 점프 애니메이터 종료
            jumpCount = 3; // 점프를 했다면 점프횟수를 돌려주기 위한 변수
        }

    }
}
