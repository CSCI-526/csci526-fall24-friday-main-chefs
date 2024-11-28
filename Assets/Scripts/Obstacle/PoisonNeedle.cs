using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonNeedle : MonoBehaviour
{
    public float reverseDuration = 5f;          // Duration of the reverse effect in seconds
    public TutorialPassManager tutorialPassManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get the MovementController component from the colliding object
        MovementController controller = other.GetComponent<MovementController>();
        if (other.gameObject.CompareTag("Player"))
        {
            if (controller != null)
            {
                // Trigger the reverse movement effect
                controller.ReverseMovement(reverseDuration);
                tutorialPassManager.TouchedPoison();
            }
        }
    }
}
