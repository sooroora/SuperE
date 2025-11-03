using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> petPrefabs;
    [SerializeField] private Vector3 sqawnPoint = new Vector3(-1, 1, 0);

    public BasePet SpawnPet(Player owner)
    {
        int rand = Random.Range(0, petPrefabs.Count);
        GameObject pet = Instantiate(petPrefabs[rand], sqawnPoint, Quaternion.identity);

        BasePet newPet = pet.GetComponent<BasePet>();
        newPet.Init(owner);
        
        return newPet;
    }
}
