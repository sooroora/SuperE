using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLooperTemp : MonoBehaviour
{
    [SerializeField] private MapPiece piece;
    [SerializeField] private Transform movingPivot;

    public float speed = 5;
    private Transform lastPivot;

    List<MapPiece> mapPieces = new List<MapPiece>();

    void Start()
    {
        mapPieces = new List<MapPiece>();

        SpawnNewMapPiece(this.transform);
        SpawnNewMapPiece(lastPivot);
        SpawnNewMapPiece(lastPivot);
    }

    void Update()
    {
        Move();
        CheckDestroyMap();
    }

    void Move()
    {
        movingPivot.position = movingPivot.position + (Vector3.left * speed * Time.deltaTime);
    }

    void CheckDestroyMap()
    {
        int removeCount = mapPieces.RemoveAll(map =>
        {
            if (map.transform.position.x <= this.transform.position.x - 10)
            {
                Destroy(map.gameObject);
                return true;
            }
            return false;
        });

        if (removeCount > 0)
        {
            SpawnNewMapPiece(lastPivot);
        }
    }

    public void SpawnNewMapPiece(Transform pieceTransform)
    {
        MapPiece mapPiece = Instantiate(piece, pieceTransform.position, Quaternion.identity);
        mapPieces.Add(mapPiece);
        mapPiece.transform.SetParent(movingPivot);

        lastPivot = mapPiece.lastPivot;
    }
}