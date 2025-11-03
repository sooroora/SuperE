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
            SoundManager.Instance.PlaySfxOnce(ESfxName.Coin);
            GameManager.Instance.AddScore(score);
            this.gameObject.transform.parent = null;
            this.gameObject.SetActive(false);
        }
    }
}
