using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class MapPiece : MonoBehaviour
{
    public Transform lastPivot;
    [SerializeField] SplineContainer spline;

    private void Start()
    {
        // start 보다 MapLooper 에서 MapPiece 소환 시 해줬으면 좋겠다!
        SpawnItems();
    }

    public void SpawnItems()
    {
        ItemSpawnManager.Instance.PlaceItems(spline);
    }

}