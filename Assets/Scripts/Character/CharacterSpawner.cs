using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> characterPrefabs;
    private Vector3 sqawnPoint = Vector3.zero;
    private int index;

    public void SpawnCharacter()
    {
        index = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = characterPrefabs[index];
        Instantiate(player, sqawnPoint, Quaternion.identity);
    }
}
