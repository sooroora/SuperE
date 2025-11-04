using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int score = 10;
    [SerializeField] private GameObject graphic;

    private void OnEnable()
    {
        graphic.SetActive(true);
    }

    protected virtual void ApplyEffect()
    {
        SoundManager.Instance.PlaySfxOnce(ESfxName.Coin);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(graphic.activeInHierarchy == false)
            return;
        
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            graphic.gameObject.SetActive(false);
            
            ItemParticleControl.Instance?.Play(this.transform);
            ApplyEffect();
        }
    }
}
