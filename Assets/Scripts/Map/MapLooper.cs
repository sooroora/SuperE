using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLooper : MonoBehaviour
{
    [SerializeField] public GameObject mapMoving;
    
    [SerializeField] float speed;
    private bool IsBackground = false;
    private GameObject count;
    private int randomValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Background();
    }
    public void HasBackground()
    {
        
        if (IsBackground == false)
        {
            
            int count = mapMoving.transform.childCount;
            
            randomValue = Random.Range(0, count);
            //Instantiate(mapMoving,)
        }
    }

    public void Background()
    {
        Vector2 pos = mapMoving.transform.localPosition;
        pos.x -= speed * Time.deltaTime;
        mapMoving.transform.localPosition = pos;
    }
}

//맵movingPiot을 움직인다.
//뒤에 있는 오브젝트에 빈 오브젝트와 앞에 있는 빈 오브젝트를 만든다.
//뒤에 있는 오브젝트는 충돌이 일어 나면 앞에 있는 오브젝트에서 movingPiot에 있는 하위 오브젝트를 불러온다
//하위 오브젝트는 movingPiot 안에 들어 있는 mappiece의 랜덤 오브젝트를 불러온다. -> 이거는 random.range(mappiece.최소값,mappiece.최대값)
//하위오브젝트 최소값과 최대값을 만든 이유는 
//이전과 똑같이 movingPiot오브젝트를 뒤로 가게 만든다
//반복