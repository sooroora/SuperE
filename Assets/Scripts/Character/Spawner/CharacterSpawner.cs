using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> characterPrefabs;
    [SerializeField] private Vector3 sqawnPoint = Vector3.zero;
    private int index;

    public Player SpawnCharacter()
    {
        index = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(characterPrefabs[index], sqawnPoint, Quaternion.identity);

        return player.GetComponent<Player>();
    }
}
