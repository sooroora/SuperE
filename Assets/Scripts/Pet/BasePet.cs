using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePet : MonoBehaviour
{
    private Player player;
    [SerializeField] private Vector3 offset = new Vector3(-1, -1, 0);

    private void OnEnable()
    {
        GameManager.Instance.OnPlayerSpawned += HandlePlayerSpawned;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerSpawned -= HandlePlayerSpawned;
    }

    private void HandlePlayerSpawned(Player spawnedPlayer)
    {
        player = spawnedPlayer;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
