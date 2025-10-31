using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelectHandler : MonoBehaviour
{
    public List<GameObject> characterPrefabs;

    public void ChangeCharacter(int index)
    {
        GameObject player = Instantiate(characterPrefabs[index], transform);
    }
}
