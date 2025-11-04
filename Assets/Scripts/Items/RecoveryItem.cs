using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryItem : Item
{
    protected override void ApplyEffect()
    {
        SoundManager.Instance.PlaySfxOnce(ESfxName.Click, 1f, 11);
        
        if(GameManager.Instance.RemainingDistance < 2.7f)
            GameManager.Instance.PlayerSpeedUp();
    }
}
