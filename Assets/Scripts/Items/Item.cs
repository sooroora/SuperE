using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int score = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 에 생각해보니까 플레이어에서 아이템 가져가서 점수 넣어주는것보다
            // 이게 더 깔끔한듯...?
            // 아이템 풀링을 만들어야겠다
            SoundManager.Instance.PlaySfxOnce(ESfxName.Click);
            GameManager.Instance.AddScore(score);
            
            
        }
    }
}
