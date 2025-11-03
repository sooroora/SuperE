using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePet : MonoBehaviour
{
    private Player player;
    [SerializeField] private Vector3 offset = new Vector3(-1, 1, 0);

    public void Init(Player player)
    {
        if (player != null)
        {
            this.player = player;
        }
        else
        {
            Debug.LogError($"Player가 없습니다");
        }
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }

    public abstract void PetSkill();
}
