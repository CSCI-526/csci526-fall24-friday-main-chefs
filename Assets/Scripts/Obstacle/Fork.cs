using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public float forkDamage = 15;
    public static int touchTimes = 0;
    public static string level = "Level1_Fork";
    public TutorialPassManager tutorialPassManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get the HealthController component from the colliding object
        HealthController controller = other.GetComponent<HealthController>();
        if (other.gameObject.CompareTag("Player"))
        {
            if (controller != null)
            {
                // Trigger the reverse movement effect
                touchTimes += 1;
                controller.forkEffect(forkDamage);
                if (tutorialPassManager != null)
                {
                    tutorialPassManager.TouchedFork();
                }
            }
        }
    }
}
