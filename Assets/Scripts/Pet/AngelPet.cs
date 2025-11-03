using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngelPet : BasePet
{
    private float skillCount = 1;
    [SerializeField] Animator animator;
    public override void PetSkill()
    {
        if (GameManager.Instance.RemainingDistance < 1)
        {
            if (skillCount > 0)
            {
                animator.SetTrigger("IsSkill");
                GameManager.Instance.PlayerSpeedUp();
                skillCount--;
            }
        }
    }
}
