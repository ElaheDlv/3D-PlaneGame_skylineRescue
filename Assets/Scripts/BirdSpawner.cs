using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;     // Assign the bird prefab in the Inspector
    public float spawnInterval = 3f;  // Time between spawns in seconds
    public float spawnDistance = 20f; // Distance from the plane to spawn the birds

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Increment time
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it’s time to spawn a new bird
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBird();
            timeSinceLastSpawn = 0f; // Reset spawn timer
        }
    }

    void SpawnBird()
    {
        // Generate a random position around the plane
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnDistance, spawnDistance),
            Random.Range(1f, 10f),  // Height above the ground
            Random.Range(-spawnDistance, spawnDistance)
        );

        // Offset spawn position relative to the spawner's position
        spawnPosition += transform.position;

        // Instantiate the bird prefab at the random position
        Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
    }
}

