using System.Collections;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject enemy; // Assign the enemy prefab in the Inspector
    public GameObject door1; // Assign Door 1 in the Inspector
    public GameObject door2; // Assign Door 2 in the Inspector

    private GameObject spawnedEnemy = null; // Track spawned enemy
    private bool roomLocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !roomLocked)
        {
            LockRoom(); // Lock the room when the player enters
            SpawnEnemy(); // Spawn one enemy
        }
    }

    private void LockRoom()
    {
        roomLocked = true;
        door1.SetActive(true); // Lock both doors by enabling them
        door2.SetActive(true);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(-10, 1); // Adjust this spawn position as needed
        spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        spawnedEnemy.SetActive(true);
    }

    private void Update()
    {
        if (roomLocked && spawnedEnemy == null) // Check if the enemy is defeated
        {
            UnlockRoom();
        }
    }

    private void UnlockRoom()
    {
        door1.SetActive(false); // Unlock doors by disabling them
        door2.SetActive(false);
        roomLocked = false;
    }
}
