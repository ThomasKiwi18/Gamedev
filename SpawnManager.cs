using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public GameObject prefabToSpawn;
    public float spawnRate = 2f;
    public float spawnRange = 10f;

    private float nextSpawnTime = 0f;

    // Reference to the player
    public Transform playerTransform;

    void Start()
    {
        // Find the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void Update()
    {

        // Spawning the towers
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            nextSpawnTime = Time.time + 1f / spawnRate;
            source.PlayOneShot(clip);
        }
    }

    void SpawnPrefab()
    {
        // Generate a random X position not overlapping with the player
        float randomX;
        do
        {
            randomX = Random.Range(-spawnRange, spawnRange);
        } while (Mathf.Abs(randomX - playerTransform.position.x) < 2f);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
