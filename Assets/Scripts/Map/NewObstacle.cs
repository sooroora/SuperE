using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewObstacle : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform slowDownFactory;
    [SerializeField] private Transform objectMoveSpeed;
    //애니메이션 불러오기
    [Header("option")]
    [SerializeField] private int Level;
    [SerializeField] private float slowDownValue;
    [SerializeField] private float currentSpeed;
    //레벨마다 이동속도 증가 변수

    void Start()
    {

    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.isPlay == true) //살았을 경우에
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                TakeObjectHit();
                //배경의 움직임을 느리게 한다.

            }
            if (collision.gameObject.CompareTag("FallZone")) //떨어졌을 때 게임 오버
            {
                Invoke("GameOverDelay", 1f);
            }
        }
        else if (GameManager.Instance.isPlay == false) //죽었을 때 게임오버
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                //1초 정도 뒤에 ui생성메서드
                Invoke("GameOverDelay", 1f);

            }


        }
        

    }

    public void GameOverDelay()
    {
        GameManager.Instance.GameOver();
    }

    public void TakeObjectHit()
    {
        //기존 배경의 이동속도 가져오기
        currentSpeed -= Level * slowDownValue * Time.deltaTime;
        
    }
}

//충돌 전에는 점수가 계속 상승한다. Time.deltatime
//충돌시 점수 스코어 플레이어 멈춤  invoke(0f,1f)
//애니메이션 적용 
//1초 정도 뒤에 ui생성