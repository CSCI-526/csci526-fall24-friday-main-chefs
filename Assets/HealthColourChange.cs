using UnityEngine;

public class HealthColourChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private HealthController playerHealth;

    private TextMesh numberText;
    private GameObject textObject;

    [SerializeField] private float healthThreshold = 70f;
    
    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        // Set initial color to red
        originalColor = Color.red;
        spriteRenderer.color = originalColor;
        
        // Find the player and get their health component
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            playerHealth = player.GetComponent<HealthController>();
        }

        CreateText();
    }

    void CreateText()
        {
            // Create a new GameObject for the text
            textObject = new GameObject("NumberText");
            textObject.transform.parent = transform; // Make it a child of the square
            
            // Position it slightly in front of the square
            textObject.transform.localPosition = new Vector3(0, 0, -1);
            
            // Add TextMesh component
            numberText = textObject.AddComponent<TextMesh>();
            numberText.text = "70";
            numberText.fontSize = 48;
            numberText.alignment = TextAlignment.Center;
            numberText.anchor = TextAnchor.MiddleCenter;
            numberText.color = Color.black;
            
            // Scale the text to be visible
            textObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }

        

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("player collision");
            // Check if we have a reference to the health controller
            if (playerHealth != null)
            {
                // Calculate health percentage
                float healthPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
                
                // Change color to green only if health percentage is at 70
                //if (Mathf.Approximately(healthPercentage, healthThreshold))
                if(healthPercentage >= healthThreshold)
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
        if (collision.gameObject.CompareTag("player"))
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Collision ended - resetting to original color");
        }
    }
}