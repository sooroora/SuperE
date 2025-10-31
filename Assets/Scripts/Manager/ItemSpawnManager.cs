using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager Instance;

    public GameObject coinPrefab;
    public GameObject speedItemPrefab;
    public SplineContainer SplineContainer;

    public int poolSize = 1000;

    [Header("Place Option")]
    public float itemSpace = 1.0f;
    public int verticalCount = 1;
    public float verticalSpace = 0.5f;


    private List<GameObject> itemPool = new List<GameObject>();

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject item = Instantiate(coinPrefab);
            item.SetActive(false);
            itemPool.Add(item);
        }
        itemPool.Add(speedItemPrefab);
    }

    private GameObject GetPooledObject()
    {
        int randomIndex = Random.Range(0, itemPool.Count);
        for (int i = 0; i < itemPool.Count; i++)
        {
            if (!itemPool[randomIndex].activeInHierarchy)
            {
                itemPool[randomIndex].SetActive(true);
                return itemPool[randomIndex];
            }
            else
            {
                randomIndex = (randomIndex + 1) % itemPool.Count;
            }
        }

        GameObject newItem = Instantiate(coinPrefab);
        newItem.SetActive(true);
        itemPool.Add(newItem);
        return newItem;
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

                    GetPooledObject();
                }
            }
        }

    }
}
