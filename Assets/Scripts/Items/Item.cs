using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int score = 10;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        SoundManager.Instance.PlaySfxOnce(ESfxName.Click);
        
    }
}
