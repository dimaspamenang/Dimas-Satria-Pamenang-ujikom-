using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 0f, spawnInterval);
    }

    void SpawnAnimal()
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        GameObject animalPrefab = animalPrefabs[randomIndex];

        GameObject animal = Instantiate(animalPrefab, transform.position, Quaternion.identity);

        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0f, 0f);
        animal.transform.position += randomOffset;
    }
}