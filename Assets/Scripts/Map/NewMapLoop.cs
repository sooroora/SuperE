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
    private int count;
    void Start()
    {
        Risfone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Risfone()
    {
        MapPiece randompivot = mapPieces[Random.Range(0, mapPieces.Count)];
        Instantiate(randompivot,movingPivot.transform.position,Quaternion.identity );
    }

    public void destroyBackground()
    {
        foreach (var map in mapPieces)
        {
            if (movingPivot.transform.position.x < mapDestroyPosition.position.x)
            {
                //Destroy(map.transform.position);
            }
        }
        
    }
}
