using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    protected Vector3 right = Vector3.zero;//오브젝트를 오른쪽으로 이동시키기 위한 변수
    protected Vector3 left = Vector3.zero;//오브젝트를 왼쪽으로 이동시키기 위한 변수
    protected Vector3 rightSpeed = Vector3.zero; //이속을 위한 변수
    protected Vector3 leftSpeed = Vector3.zero; //이속을 위한 변수
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move() // 충돌시 플레이어와의 거리를 줄이기 위한 로직
    {
        transform.position = Vector3.SmoothDamp(transform.position,transform.position + Vector3.right, ref rightSpeed, 3.0f);

        if (Vector3.Distance(transform.position, right) < 0.1f)
        {
            GameManager.Instance.isCrash = false;
        }
    }
    protected void Back() // 스피드업 아이템을 먹었을때 거리를 벌리기 위한 로직
    {
        transform.position = Vector3.SmoothDamp(transform.position, left, ref leftSpeed, 1.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.Instance.GameOver();
        }

    }


}
