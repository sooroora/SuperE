using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelPet : BasePet
{
    private float skillCount = 1;
    public override void PetSkill()
    {
        if (skillCount > 0)
        {
            GameManager.Instance.PlayerSpeedUp();
            skillCount--;
        }
    }
}
