using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    public Transform lastPivot;

    public float GetLastPivotX()
    {
        return lastPivot.position.x;
    }


}
