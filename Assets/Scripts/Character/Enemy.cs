using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 enemyDistance = new Vector3(0.6f , 0 , 0);
    private Vector3 speed = Vector3.zero; //�̼��� ���� ����
    
    Coroutine nowCoroutine;
    
    public void Approach()
    {
        Vector3 targetPosition = transform.position + enemyDistance;
        StartMoving(targetPosition);
        //nowCoroutine = StartCoroutine(Moving(targetPosition));
    }
    public void Retreat()
    {
        Vector3 targetPosition = transform.position - enemyDistance;
        StartMoving(targetPosition);
        //nowCoroutine = StartCoroutine(Moving(targetPosition));
    }
    private IEnumerator Moving(Vector3 targetPosition) 
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref speed, 0.3f);
            if (GameManager.Instance.RemainingDistance < 0.5f)
            {
                GameManager.Instance.GameOver();
                break;
            }
            yield return null;
        }
    }

    public void StartMoving(Vector3 targetPosition)
    {
        if(nowCoroutine !=null)
            StopCoroutine(nowCoroutine);
        
        nowCoroutine = StartCoroutine(Moving(targetPosition));
    }
    
    
}
