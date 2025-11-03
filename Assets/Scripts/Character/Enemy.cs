using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 enemyDistance = new Vector3(0.5f , 0 , 0);
    private Vector3 speed = Vector3.zero; //이속을 위한 변수
    
    public void Approach()
    {
        Vector3 targetPosition = transform.position + enemyDistance;
        StartCoroutine(Moving(targetPosition));
    }
    public void Retreat()
    {
        Vector3 targetPosition = transform.position - enemyDistance;
        StartCoroutine(Moving(targetPosition));
    }
    public IEnumerator Moving(Vector3 targetPosition) // 충돌시 플레이어와의 거리를 줄이기 위한 로직
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref speed, 0.5f);
            yield return null;
        }
        GameManager.Instance.isCrash = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.Instance.GameOver();
        }

    }


}
