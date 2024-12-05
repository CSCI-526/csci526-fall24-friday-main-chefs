using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonNeedle : MonoBehaviour
{
    public static int touchTimes = 0;
    public static string level = "Level1_Needle";
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
                touchTimes += 1;
                controller.ReverseMovement(reverseDuration);
                if (tutorialPassManager != null)
                {
                    tutorialPassManager.TouchedPoison();
                }
            }
        }
    }
}
