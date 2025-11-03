using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

public class ItemPlacer : MonoBehaviour
{
    public GameObject itemPrefab;
    public SplineContainer SplineContainer;

    [Header("Place Option")] public float itemSpace = 1.0f;
    public int verticalCount = 1;
    public float verticalSpace = 0.5f;


    public void PlaceItems()
    {
        List<Spline> splines = SplineContainer.Splines.ToList();

        for (int k = 0; k < splines.Count; k++)
        {
            int spawnCount = (int)(splines[k].GetLength() / itemSpace);

            for (int i = 0; i <= spawnCount; i++)
            {
                float t = i / (float)(spawnCount - 1);

                Vector3 pos      = splines[k].EvaluatePosition(t);
                Vector3 worldPos = SplineContainer.transform.TransformPoint(pos);

                for (int j = 0; j < verticalCount; j++)
                {
                    Vector3 verticalPos =
                        worldPos + Vector3.up * (verticalSpace * Mathf.Ceil(j / 2f) * (j % 2 == 0 ? -1 : 1));
                    Instantiate(itemPrefab, verticalPos, Quaternion.identity);
                }
            }
        }
    }

    public void RemoveAllItems()
    {
        Item[] items = FindObjectsOfType<Item>();

        foreach (Item item in items)
        {
            DestroyImmediate(item.gameObject);
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(ItemPlacer))]
public class ItemPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // LevelSelectUI의 기본 인스펙터 내용 그대로 사용
        base.OnInspectorGUI();

        // 그 아래에 버튼 추가
        GUILayout.Space(10);
        GUILayout.Label("아이템 생성기", EditorStyles.boldLabel);

        ItemPlacer itemPlacer = (ItemPlacer)target;
        // 인스펙터 내 해당 버튼을 클릭했다면...
        if (GUILayout.Button("\n아이템 배치\n"))
        {
            // "ClearLevel" 을 1로 설정합니다.
            itemPlacer.PlaceItems();
        }

        GUILayout.Space(10);
        if (GUILayout.Button("배치된 아이템 제거 \n(⚠️배치된 Item 다 지워집니다!!!)"))
        {
            itemPlacer.RemoveAllItems();
        }
    }
}
#endif