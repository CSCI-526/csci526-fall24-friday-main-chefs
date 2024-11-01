using UnityEngine;

public class HealthColorChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private HealthController playerHealth;

    [SerializeField] private float healthThreshold = 70f;
    
    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Set initial color to red
        originalColor = Color.red;
        spriteRenderer.color = originalColor;
        
        // Find the player and get their health component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<HealthController>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if we have a reference to the health controller
            if (playerHealth != null)
            {
                // Calculate health percentage
                float healthPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
                
                // Change color to green only if health percentage is at 70
                if (Mathf.Approximately(healthPercentage, healthThreshold))
                {
                    spriteRenderer.color = Color.green;
                    Debug.Log($"Health at threshold: {healthPercentage}% - changing to green!");
                }
                else
                {
                    Debug.Log($"Current health: {healthPercentage}%, Required: {healthThreshold}%");
                }
            }
            else
            {
                Debug.LogWarning("Player HealthController component not found!");
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Collision ended - resetting to original color");
        }
    }
}