using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // Reference to the object to spawn
    public Transform spawnPoint;      // Reference to the empty GameObject (spawn point)
    public Collider playerCollider;   // Reference to the player's collider (assigned in the Inspector)

    void Start()
    {
        if (playerCollider == null)
        {
            Debug.LogError("Player Collider not assigned in the Inspector!");
        }

        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point not assigned in the Inspector!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))  // Make sure the player has the "Player" tag
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Check if the spawn point and object to spawn are assigned
        if (objectToSpawn != null && spawnPoint != null)
        {
            // Spawn the object at the position and rotation of the spawn point
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Object spawned at position: " + spawnPoint.position);
        }
        else
        {
            Debug.LogError("Object to spawn or spawn point is not assigned!");
        }
    }
}
