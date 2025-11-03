using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class Yohan : Player
{
    protected Vector3 Speed = Vector3.zero;
    [SerializeField] LayerMask item;
    protected Transform Player;
    private void Awake()
    {
        Player = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(Player.position, 4f, item);
        foreach (Collider2D hit in hits)
        {
            hit.transform.position = Vector3.SmoothDamp(hit.transform.position, Player.position + Vector3.right, ref Speed, 0.5f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
