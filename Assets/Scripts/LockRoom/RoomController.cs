using System.Collections.Generic; // For List
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject enemy; 
    public GameObject door1; 
    public GameObject door2; 

    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Track multiple spawned enemies
    private bool roomLocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !roomLocked)
        {
            LockRoom(); // Lock the room when the player enters
            SpawnEnemies(); // Spawn two enemies
        }
    }

    private void LockRoom()
    {
        roomLocked = true;
        door1.SetActive(true); // Lock both doors by enabling them
        door2.SetActive(true);
    }

    private void SpawnEnemies()
    {
        Vector2 spawnPosition1 = new Vector2(-10, 0); // Spawn position for first enemy
        Vector2 spawnPosition2 = new Vector2(-10, 1); // Slightly offset position for second enemy

        GameObject enemy1 = Instantiate(enemy, spawnPosition1, Quaternion.identity);
        GameObject enemy2 = Instantiate(enemy, spawnPosition2, Quaternion.identity);

        spawnedEnemies.Add(enemy1);
        spawnedEnemies.Add(enemy2);

        enemy1.SetActive(true);
        enemy2.SetActive(true);
    }

    private void Update()
    {
        if (roomLocked && AllEnemiesDefeated()) // Check if both enemies are defeated
        {
            UnlockRoom();
        }
    }

    private bool AllEnemiesDefeated()
    {
        // Remove any null entries for destroyed enemies
        spawnedEnemies.RemoveAll(enemy => enemy == null);

        // If all enemies are destroyed, the list will be empty
        return spawnedEnemies.Count == 0;
    }

    private void UnlockRoom()
    {
        door1.SetActive(false); // Unlock doors by disabling them
        door2.SetActive(false);
        roomLocked = false;
    }
}
