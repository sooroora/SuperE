using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Vector3 sqawnPoint = new Vector3(-2.7f, 0 , 0);

    public Enemy SpawnEnemy()
    {
        int rand = Random.Range(0, enemyPrefabs.Count);
        GameObject enemy = Instantiate(enemyPrefabs[rand], sqawnPoint, Quaternion.identity);

        return enemy.GetComponent<Enemy>();
    }
}
