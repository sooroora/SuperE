using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sura : Player
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible)
        {
            return;
        }
        else
        {
            if (collision.GetComponent<Obstacle>() != null) //플레이어가 충돌시 벽 인지 체크
            {
                soundManager.PlaySfxOnce(ESfxName.Crash);
                StartCoroutine(InvincibleCoroutine());
                GameManager.Instance.Crash();
            }
        }
    }


}
