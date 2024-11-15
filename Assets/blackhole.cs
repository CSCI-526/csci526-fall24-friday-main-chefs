using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // Disable the player object
            collision.gameObject.SetActive(false);

            // Optional: Play a sound or particle effect
            Debug.Log("Player has been sucked into the black hole!");
        }
    }
}
