using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
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
        List<MapPiece> toDestroy = mapPieces.FindAll(map =>
        {
            if (map.transform.position.x <= this.transform.position.x - 10)
            {
                return true;
            }
            return false;
        });

        toDestroy.ForEach(map =>
            {
                Item[] items = map.gameObject.GetComponentsInChildren<Item>();
                foreach (Item item in items)
                {
                    item.transform.parent = null;
                    item.gameObject.SetActive(false);
                }
            }
        );

        int destroyCount = mapPieces.RemoveAll(map =>
        {
            if (toDestroy.Contains(map))
            {
                Destroy(map.gameObject);
                return true;
            }
            return false;
        });

        if (destroyCount > 0)
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