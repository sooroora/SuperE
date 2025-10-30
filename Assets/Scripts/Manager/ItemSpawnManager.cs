using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public SplineContainer SplineContainer;

    public int poolSize = 1000;

    [Header("Place Option")]
    public float itemSpace = 1.0f;
    public int verticalCount = 1;
    public float verticalSpace = 0.5f;


    private Queue<GameObject> itemPool = new Queue<GameObject>();

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.SetActive(false);
            itemPool.Enqueue(obj);
        }
    }

    public void PlaceItems()
    {
        List<Spline> splines = SplineContainer.Splines.ToList();

        for (int k = 0; k < splines.Count; k++)
        {
            int spawnCount = (int)(splines[k].GetLength() / itemSpace);

            for (int i = 0; i <= spawnCount; i++)
            {
                float t = i / (float)(spawnCount - 1);

                Vector3 pos = splines[k].EvaluatePosition(t);
                Vector3 worldPos = SplineContainer.transform.TransformPoint(pos);

                for (int j = 0; j < verticalCount; j++)
                {
                    Vector3 verticalPos = worldPos + Vector3.up * (verticalSpace * Mathf.Ceil(j / 2f) * (j % 2 == 0 ? -1 : 1));
                    

                    if (itemPool.Count > 0)
                    {
                        GameObject item = itemPool.Dequeue();
                        item.transform.position = verticalPos;
                        item.SetActive(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

    }
}
