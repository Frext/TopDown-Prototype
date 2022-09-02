using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    [Space]
    [SerializeField] private float spawnRangeHorizontal;
    [SerializeField] private float spawnLinePos;

    [Space]
    [SerializeField] private float startDelay;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeHorizontal, spawnRangeHorizontal), animalPrefabs[animalIndex].transform.position.y, spawnLinePos);

        spawnPos = transform.InverseTransformDirection(spawnPos);

        Instantiate(animalPrefabs[animalIndex], spawnPos, transform.rotation, transform);
    }
}
