using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapLooper : MonoBehaviour
{
    [SerializeField] private Transform mapDestroyPosition; //포지션 x값이 같으면 삭제

    [Header("option")]

    [SerializeField] private List<GameObject> mapPiecePrefab;      // 생성할 맵의 원본 -> 원본 들

    [SerializeField] private float speed;
    [SerializeField] private GameObject movingPivot;    // 이동의 주체

    [SerializeField] List<MapPiece> mapPieces;  // 생성된 맵들
    [SerializeField] private GameObject baseGround;
    
    private int probability;
    [SerializeField] private float lastPosy;


    void Start()
    {
        // 몇 개 생성해두기
        for (int i = 0; i < 5; i++)
        {
            Respawn();    
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartMap();
        MovePivot();
        DestroyBackground();

    }
    public void Respawn()  // 생성될 mapPiece 와 구분할 수 있게 매개변수 이름을 바꿔줬어요!
    {
        // 생성할 프리팹을 고른다.
        // 마지막 생성된 맵 뒤에 새로운 맵을 생성한다.
        //  마지막 맵 찾기
        //  마지막 맵 끝 위치 찾기
        //  새로운 맵 생성
        //  새로운 맵 위치 조정

        // 기존의 맵 삭제
        // 는!! destroy에서 진행!
        // Respawn 에서는 Respawn의 행동만!
        // if (lastMapPiece != null)
        // {
        //     mapPieces.Remove(lastMapPiece);
        //     Destroy(lastMapPiece.gameObject);
        // }


        // 새로운 맵 생성
        GameObject prefab = mapPiecePrefab[Random.Range(0, mapPiecePrefab.Count)];         //프레펩이름의 게임오브젝트 생성
        GameObject go = Instantiate(prefab);        // 클론 생성

        // 마지막 맵
        float lastPosX = 0; //x의 위치 값 변경시 같이 이동이 됨

        if (mapPieces.Count >= 1)   // 1개라도 맵이 생성 되어 있으면
        {
            MapPiece lastPiece = mapPieces[mapPieces.Count - 1]; //mapPieces의 리스트수를?? -1을 해라 앞에서 리스트가 삭제되었기 때문에
            lastPosX = lastPiece.GetLastPivotX();                // 다음 생성 위치
            lastPosy = lastPiece.lastPivot.position.y;
        }

        go.transform.SetParent(movingPivot.transform);          // 피벗 하위로 옮기기
        go.transform.position = new Vector3(lastPosX, lastPosy, 0);

        MapPiece piece = go.GetComponent<MapPiece>();
        mapPieces.Add(piece);
    }

    public void DestroyBackground()
    {
        for (int i = 0; i < mapPieces.Count; i++)
        {
            MapPiece piece = mapPieces[i];
            if (piece.transform.position.x < mapDestroyPosition.position.x)
            {
                
                DivideItems(piece);
                
                if (piece != null)
                {
                    mapPieces.Remove(piece);
                    Destroy(piece.gameObject);
                }
                
                // 리스폰
                Respawn();
            }
        }

    }
    public void MovePivot()
    {
        Vector2 pos = movingPivot.transform.position;

        pos.x -= speed * Time.deltaTime;
        movingPivot.transform.position = pos;

    }

    // StartMap(BaseGround) 가 MovingPivot 안에 있으면 필요 없어요~! (부모를 따라가니까!!)
    // Start 에서만 동작하는 코드였기 때문에 처음 시작할때만 작동해서
    // 원하던 동작은 못했을 거예요 ㅠㅠ~~~!
    // public void StartMap()
    // {
    //     Vector2 pos = BaceGround.transform.position;
    //     pos.x -= speed * Time.deltaTime;
    //     BaceGround.transform.position = pos;
    // }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }


    void DivideItems(MapPiece mapPiece)
    {
        Item[] items = mapPiece.gameObject.GetComponentsInChildren<Item>();
        foreach (Item item in items)
        {
            item.transform.parent = null;
            item.gameObject.SetActive(false);
        }
    }
}

