using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapLoop : MonoBehaviour
{
    [SerializeField] private GameObject movingPivot;
    [SerializeField] private Transform mapDestroyPosition;

    [Header("option")]
    [SerializeField] private float speed;
    [SerializeField] List<MapPiece> mapPieces;
    [SerializeField] private float width;
    [SerializeField] private float spawnDistance;
    [SerializeField] private GameObject mapPieseSetParse;
    [SerializeField] private Transform sponeZone;
    [SerializeField] private GameObject mapiecePrefeb;
    void Start()
    {
        //mapPieseSetParse = transform.SetParent(movingPivot);
        Rispone(movingPivot.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyBackground();


    }
    public void Rispone(Transform movingPivot)
    {
        MapPiece randompivot = mapPieces[Random.Range(0, mapPieces.Count)];
        MapPiece mapRisfon = Instantiate(randompivot, movingPivot.transform.position, Quaternion.identity);
        mapRisfon.transform.SetParent(movingPivot);
        movingPivot = mapRisfon.transform;
        if (movingPivot.transform.position.x < mapDestroyPosition.position.x)
        {
            mapPieces.Remove(mapPieces[0]);
            Destroy(movingPivot.gameObject);
            var newMapiece = Instantiate(mapiecePrefeb,new Vector3(movingPivot.position.x,movingPivot.position.y ) , Quaternion.identity);

            Instantiate(newMapiece);

        }

    }

    public void DestroyBackground()
    {
        foreach (var map in mapPieces)
        {
            if (movingPivot.transform.position.x < mapDestroyPosition.position.x)
            {
                if (map != null)
                {
                    Destroy(map.gameObject);
                }


            }
        }

    }
    public void Move()
    {
        Vector2 pos = movingPivot.transform.position;
        pos.x -= speed * Time.deltaTime;
        movingPivot.transform.position = pos;
    }
}
    
        
