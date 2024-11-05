using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTile : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorHandler door; 
    public bool isSteppedOn ; 
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private HealthController playerHealth; 

    private TextMesh numberText;
    private GameObject textObject;

    [SerializeField] private float healthThreshold = 70f;

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on this object!");
            return;
        }
        
        // Set initial color to red
        originalColor = Color.red;
        spriteRenderer.color = originalColor;
        Debug.Log("Initial color set to red");
        
        // Find the player and get their health component
        GameObject player = GameObject.FindGameObjectWithTag("PlayerSprite");
        if (player != null)
        {
            playerHealth = player.GetComponent<HealthController>();
            Debug.Log("Found player object with health controller");
            Debug.Log($"Initial player health: {playerHealth.currentHealth}/{playerHealth.maxHealth}");
        }
        else
        {
            Debug.LogError("No object with 'Player' tag found in the scene!");
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

    CreateText();
    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");
        
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("PlayerSprite"))
        {
            Debug.Log("Collision is with player!");
            
            // Check if we have a reference to the health controller
            if (playerHealth != null)
            {
                // Calculate health percentage
                float healthPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
                Debug.Log($"Current health percentage: {healthPercentage}%");
                
                // Change color to green only if health percentage is at 70
                if (Mathf.Approximately(healthPercentage, healthThreshold))
                {
                    spriteRenderer.color = Color.green;
                    Debug.Log("Color changed to green!");
                }
                else
                {
                    Debug.Log($"Health not at threshold. Current: {healthPercentage}%, Required: {healthThreshold}%");
                }
            }
            else
            {
                Debug.LogError("PlayerHealth is null despite collision with player!");
            }
        }
    }

    // Also add debug for trigger events in case collider is set as trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger detected with: {collision.gameObject.name}");
        
        if (collision.CompareTag("PlayerSprite"))
        {
            Debug.Log("Trigger is with player!");
            
            if (playerHealth != null)
            {
                float healthPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
                Debug.Log($"Current health percentage: {healthPercentage}%");
                
                if (healthPercentage>= healthThreshold)
                {
                    spriteRenderer.color = Color.green;
                    Debug.Log("Color changed to green!");
                    isSteppedOn = true;
                    door.OpenDoor(); // Call the door's open method
                    spriteRenderer.color = Color.green; // Change color to green when activated
                    Debug.Log("Pressure tile activated, door opening.");
                }
                else
                {
                    Debug.Log($"Health not at threshold. Current: {healthPercentage}%, Required: {healthThreshold}%");
                }
            }
            else
            {
                Debug.LogError("PlayerHealth is null despite trigger with player!");
            }
        }

        // if (collision.CompareTag("PlayerSprite")) 
        // {
        //     isSteppedOn = true;
        //     door.OpenDoor(); // Call the door's open method
        //     spriteRenderer.color = Color.green; // Change color to green when activated
        //     Debug.Log("Pressure tile activated, door opening.");
        // }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerSprite"))
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Collision ended - color reset to red");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSprite"))
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Trigger ended - color reset to red");
        }
    }
}


    // // Check if the player steps on the tile
    //  private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("PlayerSprite")) 
    //     {
    //         isSteppedOn = true;
    //         door.OpenDoor(); // Call the door's open method
    //         spriteRenderer.color = Color.green; // Change color to green when activated
    //         Debug.Log("Pressure tile activated, door opening.");
    //     }
    // }

    // Check if the player leaves the tile
   /* private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSprite")) 
        {
            isSteppedOn = false;
            door.CloseDoor(); // Call the door's close method
            spriteRenderer.color = Color.red; // Change color back to red when deactivated
            Debug.Log("Pressure tile deactivated, door closing.");
        }
    }*/


