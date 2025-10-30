using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapLooper : MonoBehaviour
{
    [SerializeField] private GameObject movingPivot;
    [SerializeField] private Transform movingPosition;
    [SerializeField] private Transform lastMovePosition;
    [SerializeField] private float speed;
    [SerializeField] List<MapPiece> mapPieces;
    [SerializeField] private Transform LastPivot;
    [SerializeField] private float width;
    [SerializeField] private float spawnDistance;


    private bool hasSpawned = false;
    private void Start()
    {

        BackgroundInstatiate();
    }
    private void Update()
    {
        Move();
        NewMove();

    }
    public void BackgroundInstatiate()
    {
        var randomBackground = mapPieces[Random.Range(0, mapPieces.Count)];

       MapPiece clone = Instantiate(randomBackground, transform.position, Quaternion.identity);
        if (movingPosition.transform.position.x <= lastMovePosition.transform.position.x)
        {
            Destroy(clone);
        }

    }

    public void Move()
    {
        Vector3 pos = movingPivot.transform.position;
        pos.x -= speed * Time.deltaTime;
        movingPivot.transform.position = pos;

    }

    public void NewMove()
    {
        if(movingPosition.transform.position.x <= lastMovePosition.transform.position.x && !hasSpawned)
        {

            var randomBackground = mapPieces[Random.Range(0, mapPieces.Count)];

            Instantiate(randomBackground, new Vector3(LastPivot.transform.position.x, transform.position.y, 0), Quaternion.identity);

            hasSpawned = true;
        }
  
    }

   


}
