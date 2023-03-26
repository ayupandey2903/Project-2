using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Range Settings")]
    // public variables with tooltips
    [Tooltip("Range of spawning in X axis (in m)")] public float spawnRangeX = 10f;              // spawn range in x axis
    [Tooltip("Range of spawning in Z axis (in m)")] public float spawnRangeZ = 0f;               // spawn range in z axis
    [Tooltip("Position of spawning in X axis (in m)")] public float spawnPosX = 0f;              // spawn position in x axis 
    [Tooltip("Position of spawning in Z axis (in m)")] public float spawnPosZ = 60f;             // spawn position in z axis 
    [Tooltip("Y axis Rotation of spawned animal(in Deg)")] public float spawnRotationY = 180f;   // spawn rotation

    [Header("Spawn Timings Settings")]
    [Tooltip("in Sec")] public float spawnDelay = 2f;                                            // delay before spawning
    [Tooltip("in Sec")] public float spawnInterval = 1.5f;                                       // interval between spawns

    // give heading in inspector
    [Header("Animal Prefab Settings")]
    [Tooltip("Animal Prefab")][SerializeField] public GameObject[] animalPrefab;                 // array of animal prefabs
        
    // Start is called before the first frame update
    void Start() 
    {
        InvokeRepeating(nameof(SpawnAnimal), spawnDelay, spawnInterval);      // invoke spawnAnimal method with delay and interval
    }

    void SpawnAnimal ()
    {
        Vector3 spawnPos;
        // generate random animal spawn position after checking spawner location
        if (spawnRangeX != 0)
        {
            spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        }
        else
        {
            spawnPos = new(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        }
       

        int animalIndex = Random.Range(0, animalPrefab.Length);               // generate random animal index for animal prefab array

        Quaternion spawnRotation = Quaternion.Euler(0, spawnRotationY, 0);    // generate spawn rotation
        
        Instantiate(animalPrefab[animalIndex], spawnPos, spawnRotation);      // spawn animal at random position
    }
}
