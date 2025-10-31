using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapLooper : MonoBehaviour
{
    [SerializeField] private GameObject movingPivot;
    [SerializeField] private Transform movingPosition;
    [SerializeField] private Transform mapDestroyPosition;
    [SerializeField] private Transform LastPivot;
    
    
    [Header("option")]
    [SerializeField] private float speed;
    [SerializeField] List<MapPiece> mapPieces;
    [SerializeField] private float width;
    [SerializeField] private float spawnDistance;
    
    


    private bool hasSpawned = false;
    private void Start()
    {
        BackgroundInstatiate(this.transform);
    }
    
    private void Update()
    {
        Move();
        SpawnNewMapPiece();
        //BackgroundInstatiate(movingPosition);
        CheckBackgroundDestroy();

    }
    public void BackgroundInstatiate(Transform nowTransform)
    {
        var randomBackground = mapPieces[Random.Range(0, mapPieces.Count)];

        MapPiece clone = Instantiate(randomBackground, nowTransform.position, Quaternion.identity);
        LastPivot = clone.lastPivot;
         clone.transform.SetParent(movingPosition);
        if (LastPivot.transform.position.x <= mapDestroyPosition.transform.position.x)
        {
            Destroy(clone.transform.SetParent(movingPosition));
        }
       
       

    }

    void CheckBackgroundDestroy()
    {

        // clone 한 애들을 mapDestroyPosition이 넘으면 Destroy 할 수 있도록 구현 필요
        if (mapDestroyPosition.position.x > movingPosition.position.x)
        {

            Destroy(LastPivot.transform);
        }

        //void movingPosition()
        // if (movingPosition.transform.position.x <= mapDestroyPosition.transform.position.x)
        //{
        //    Destroy(clone);
        //}
    }

    public void Move()
    {
        Vector3 pos = movingPivot.transform.position;
        pos.x -= speed * Time.deltaTime;
        movingPivot.transform.position = pos;
        
    }

    public void SpawnNewMapPiece()
    {
        //Debug.Log("Last"+ LastPivot.transform.position.x);
        //Debug.Log("destroy" + mapDestroyPosition.transform.position.x);
        if (LastPivot.transform.position.x <= mapDestroyPosition.transform.position.x)
        {
            BackgroundInstatiate(LastPivot.transform);
            
        }

    }

}  



