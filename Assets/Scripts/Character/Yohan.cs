using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class Yohan : Player
{
    private Vector3 Speed = Vector3.zero;
    [SerializeField] LayerMask item;
    private void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 4f, item);
        foreach (Collider2D hit in hits)
        {
            hit.transform.position = Vector3.SmoothDamp(hit.transform.position, transform.position + new Vector3(0, 0.5f), ref Speed, 0.1f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
}
