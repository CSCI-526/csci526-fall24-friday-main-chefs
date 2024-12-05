using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTile : MonoBehaviour
{
    public DoorHandler door; 
    public bool isSteppedOn;
    private bool isActivated = false; // New flag to track if tile has been activated
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
        
        originalColor = Color.red;
        spriteRenderer.color = originalColor;
        Debug.Log("Initial color set to red");
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
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

        CreateText();
    }

    void CreateText()
    {
        textObject = new GameObject("NumberText");
        textObject.transform.parent = transform;
        textObject.transform.localPosition = new Vector3(0, 0, -1);
        
        numberText = textObject.AddComponent<TextMesh>();
        numberText.text = healthThreshold.ToString() + "%";
        numberText.fontSize = 48;
        numberText.alignment = TextAlignment.Center;
        numberText.anchor = TextAnchor.MiddleCenter;
        numberText.color = Color.black;
        
        textObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActivated && collision.gameObject.CompareTag("Player"))
        {
            CheckAndActivateTile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated && collision.CompareTag("Player"))
        {
            CheckAndActivateTile();
        }
    }

    private void CheckAndActivateTile()
    {
        if (playerHealth != null)
        {
            float healthPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100f;
            Debug.Log($"Current health percentage: {healthPercentage}%");
            
            if (healthPercentage >= healthThreshold)
            {
                ActivateTile();
            }
            else
            {
                Debug.Log($"Health not at threshold. Current: {healthPercentage}%, Required: {healthThreshold}%");
            }
        }
        else
        {
            Debug.LogError("PlayerHealth is null!");
        }
    }

    private void ActivateTile()
    {
        isActivated = true;
        isSteppedOn = true;
        spriteRenderer.color = Color.green;
        door.OpenDoor();
        Debug.Log("Tile permanently activated, door opening.");
    }

    // Modified exit handlers to check isActivated flag
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Collision ended - not activated, color reset to red");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            spriteRenderer.color = originalColor;
            Debug.Log("Trigger ended - not activated, color reset to red");
        }
    }
}