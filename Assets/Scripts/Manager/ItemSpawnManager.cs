using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager Instance;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private List<GameObject> specialItemPrefab;
    [SerializeField] private SplineContainer SplineContainer;

    [SerializeField] private int coinPoolSize = 100;
    [SerializeField] private int specialPoolSize = 1;

    [Header("Place Option")]
    [SerializeField] private float itemSpace = 1.0f;
    [SerializeField] private int verticalCount = 1;
    [SerializeField] private float verticalSpace = 0.5f;


    private List<GameObject> coinItemPool = new List<GameObject>();
    private List<GameObject> specialItemPool = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < coinPoolSize; i++)
        {
            GameObject item = Instantiate(coinPrefab);
            item.SetActive(false);
            coinItemPool.Add(item);
        }

        for (int i = 0; i < specialPoolSize; i++)
        {
            foreach (var item in specialItemPrefab)
            {
                GameObject obj = Instantiate(item);
                specialItemPool.Add(obj);
            }
        }
    }

    private GameObject GetCoinPooledObject()
    {
        for (int i = 0; i < coinItemPool.Count; i++)
        {
            if (!coinItemPool[i].activeInHierarchy)
            {
                coinItemPool[i].SetActive(true);
                return coinItemPool[i];
            }
        }

        GameObject newItem = Instantiate(coinPrefab);
        newItem.SetActive(true);
        coinItemPool.Add(newItem);
        return newItem;
    }

    private GameObject GetSpecialPooledObject()
    {
        for (int i = 0; i < coinItemPool.Count; i++)
        {
            if (!coinItemPool[i].activeInHierarchy)
            {
                coinItemPool[i].SetActive(true);
                return coinItemPool[i];
            }
        }

        GameObject newItem = Instantiate(coinPrefab);
        newItem.SetActive(true);
        coinItemPool.Add(newItem);
        return newItem;
    }

    public void PlaceItems(SplineContainer mapSpline)
    {
        List<Spline> splines = mapSpline.Splines.ToList();

        bool isSpecialSpawned = false;

        for (int k = 0; k < splines.Count; k++)
        {
            int spawnCount = (int)(splines[k].GetLength() / itemSpace);

            for (int i = 0; i <= spawnCount; i++)
            {
                float t = i / (float)(spawnCount - 1);

                Vector3 pos = splines[k].EvaluatePosition(t);
                Vector3 worldPos = mapSpline.transform.TransformPoint(pos);

                for (int j = 0; j < verticalCount; j++)
                {
                    Vector3 verticalPos = worldPos + Vector3.up * (verticalSpace * Mathf.Ceil(j / 2f) * (j % 2 == 0 ? -1 : 1));

                    if (!isSpecialSpawned && )
                    {

                    }
                    else
                    {
                        GameObject spawnedItem = GetSpecialPooledObject();
                        spawnedItem.transform.position = verticalPos;
                        spawnedItem.transform.SetParent(mapSpline.transform);
                    }
                }
            }
        }

    }
}
