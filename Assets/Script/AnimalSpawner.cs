using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnAnimal();
            spawnTimer = 0f;
        }
    }

    void SpawnAnimal()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        GameObject animal = Instantiate(animalPrefabs[animalIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
}