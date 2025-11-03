
using UnityEngine;
using UnityEngine.Splines;

public class MapPiece : MonoBehaviour
{
    public Transform lastPivot;
    [SerializeField] SplineContainer spline;
    
    private void Start()
    {
        SpawnItems();
    }

    public float GetLastPivotX()
    {
        return lastPivot.position.x;
    }

    public void SpawnItems()
    {
        if(spline == null)
            return;
        
        ItemSpawnManager.Instance.PlaceItems(spline);
    }
    
}

