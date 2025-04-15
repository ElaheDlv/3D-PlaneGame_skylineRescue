using UnityEngine;

public class RandomPrefabPlacer : MonoBehaviour
{
    public GameObject prefab; // Assign the prefab in the inspector
    public int numberOfPrefabs = 10; // Number of prefabs to place
    public Vector3 areaSize = new Vector3(500, 0, 500); // Define the area for placement

    void Start()
    {
        PlacePrefabs();

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Print the name of each GameObject
        foreach (GameObject obj in allObjects)
        {
            Debug.Log("GameObject Name: " + obj.name);
        }
    }

    void PlacePrefabs()
    {
        Instantiate(prefab, new Vector3(100, 50, 105), Quaternion.identity);
        Instantiate(prefab, new Vector3(105, 50, 100), Quaternion.identity);
        Instantiate(prefab, new Vector3(100, 50, 100), Quaternion.identity);
        Instantiate(prefab, new Vector3(100, 50, 105), Quaternion.identity);
        Instantiate(prefab, new Vector3(95, 50, 105), Quaternion.identity);
        Instantiate(prefab, new Vector3(550, 0, 905), Quaternion.identity);
        Instantiate(prefab, new Vector3(555, 0, 900), Quaternion.identity);
        Instantiate(prefab, new Vector3(550, 0, 900), Quaternion.identity);
        Instantiate(prefab, new Vector3(550, 0, 905), Quaternion.identity);
        Instantiate(prefab, new Vector3(545, 0, 905), Quaternion.identity);
        Instantiate(prefab, new Vector3(800, 0, 855), Quaternion.identity);
        Instantiate(prefab, new Vector3(805, 0, 850), Quaternion.identity);
        Instantiate(prefab, new Vector3(800, 0, 850), Quaternion.identity);
        Instantiate(prefab, new Vector3(800, 0, 855), Quaternion.identity);
        Instantiate(prefab, new Vector3(795, 0, 855), Quaternion.identity);
    }
}

/*
using UnityEngine;

public class RandomPrefabPlacer : MonoBehaviour
{
    public GameObject prefab; // Assign the prefab in the inspector
    public int numberOfPrefabs = 10; // Number of prefabs to place
    public Vector3 areaSize = new Vector3(500, 0, 500); // Define the area for placement
    public float spawnRadius = 100f; // Radius to check for overlap
    public int maxAttempts = 100; // Max attempts to find a clear position

    void Start()
    {
        PlacePrefabs();
    }

    void PlacePrefabs()
    {
        int placedPrefabs = 0;

        while (placedPrefabs < numberOfPrefabs)
        {
            // Attempt to find a clear position
            bool positionFound = false;
            int attempts = 0;
            Vector3 randomPosition = Vector3.zero;

            while (!positionFound && attempts < maxAttempts)
            {
                // Generate random position within the defined area
                randomPosition = new Vector3(
                    Random.Range(0, 1000), // X range
                    20, // Fixed height
                    Random.Range(0, 1000)  // Z range
                );

                // Check if the position is clear
                if (Physics.OverlapSphere(randomPosition, spawnRadius).Length == 0)
                {
                    positionFound = true;
                }
                attempts++;
            }

            // If a clear position was found, instantiate the prefab
            if (positionFound)
            {
                Instantiate(prefab, randomPosition, Quaternion.identity);
                Debug.Log("Spawned prefab at position: " + randomPosition);
                placedPrefabs++;
            }
            else
            {
                Debug.LogWarning("Could not find a clear position for prefab " + (placedPrefabs + 1));
            }
        }
    }
}
*/