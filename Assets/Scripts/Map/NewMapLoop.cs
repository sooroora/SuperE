using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapLoop : MonoBehaviour
{
    [SerializeField] private Transform mapDestroyPosition;

    [Header("option")]

    [SerializeField] private GameObject mapPiecePrefab;      // 생성할 맵의 원본 -> 원본 들

    [SerializeField] private float speed;
    [SerializeField] private GameObject movingPivot;    // 이동의 주체

    [SerializeField] List<MapPiece> mapPieces;  // 생성된 맵들
    
    
    
    
    
    void Start()
    {


        // mapPieseSetParse = transform.SetParent(movingPivot);
        // Rispone(movingPivot.transform);
        Rispone(null);
        Rispone(null);
        Rispone(null);
    }

    // Update is called once per frame
    void Update()
    {
        MovePivot();
        DestroyBackground();


    }
    public void Rispone(MapPiece mapPiece)
    {
        // 생성할 프리팹을 고른다.
        // 마지막 생성된 맵 뒤에 새로운 맵을 생성한다.
        //  마지막 맵 찾기
        //  마지막 맵 끝 위치 찾기
        //  새로운 맵 생성
        //  새로운 맵 위치 조정

        // 기존의 맵 삭제
        if (mapPiece != null)
        {
            mapPieces.Remove(mapPiece);
            Destroy(mapPiece.gameObject);
        }


        // 새로운 맵 생성
        GameObject prefab = mapPiecePrefab;
        GameObject go = Instantiate(prefab);        // 클론 생성

        // 마지막 맵
        float lastPosX = 0;

        if (mapPieces.Count >= 1)   // 1개라도 맵이 생성 되어 있으면
        {
            MapPiece lastPiece = mapPieces[mapPieces.Count - 1];
            lastPosX = lastPiece.GetLastPivotX();          // 다음 생성 위치
        }

        go.transform.SetParent(movingPivot.transform);  // 피벗 하위로 옮기기
        go.transform.position = new Vector3(lastPosX, 0, 0);

        MapPiece piece = go.GetComponent<MapPiece>();
        mapPieces.Add(piece);





        //MapPiece randompivot = mapPieces[Random.Range(0, mapPieces.Count)];
        //MapPiece mapRisfon = Instantiate(randompivot, movingPivot.transform.position, Quaternion.identity);
        //mapRisfon.transform.SetParent(movingPivot);
        //movingPivot = mapRisfon.transform;
        //if (movingPivot.transform.position.x < mapDestroyPosition.position.x)
        //{
        //    mapPieces.Remove(mapPieces[0]);
        //    Destroy(movingPivot.gameObject);
        //    var newMapiece = Instantiate(mapPiecePrefeb,new Vector3(movingPivot.position.x,movingPivot.position.y ) , Quaternion.identity);

        //    Instantiate(newMapiece);

        //}

    }

    public void DestroyBackground()
    {
        
        for(int i = 0; i < mapPieces.Count;i++)
        {
            MapPiece piece = mapPieces[i];
            if (piece.transform.position.x < mapDestroyPosition.position.x)
            {
 
                    // Destroy(map.gameObject);
                    // 리스폰
                    Rispone(piece);
            }
        }

    }
    public void MovePivot()
    {
        Vector2 pos = movingPivot.transform.position;
        pos.x -= speed * Time.deltaTime;
        movingPivot.transform.position = pos;
    }
}
    
        
