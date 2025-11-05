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
            if (collision.GetComponent<Obstacle>() != null) 
            {
                int destroy = Random.Range(1, 11);
                Debug.Log(destroy);
                if (destroy <= 3)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    soundManager.PlaySfxOnce(ESfxName.Crash);
                    StartCoroutine(InvincibleCoroutine());
                    GameManager.Instance.Crash();
                }
            }
        }
    }
}



