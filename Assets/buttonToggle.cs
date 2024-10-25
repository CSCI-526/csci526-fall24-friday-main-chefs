using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonToggle : MonoBehaviour
{
    [Header("Color Settings")]
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;
    
    [Header("Bridge Settings")]
    public GameObject bridge;
    private bool isBridgeActive = false;
    
    [Header("Interaction Settings")]
    public float cooldownTime = 0.5f;  // Prevents rapid toggling
    private float lastToggleTime = 0f;
    
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the object!");
            return;
        }
        
        // Set initial color
        spriteRenderer.color = normalColor;
        
        // Set initial bridge state
        if (bridge != null)
        {
            bridge.SetActive(isBridgeActive);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // Change color
            spriteRenderer.color = highlightColor;
            
            // Toggle bridge if cooldown has passed
            if (Time.time - lastToggleTime >= cooldownTime)
            {
                ToggleBridge();
                lastToggleTime = Time.time;
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            spriteRenderer.color = normalColor;
        }
    }
    
    void ToggleBridge()
    {
        if (bridge != null)
        {
            isBridgeActive = !isBridgeActive;
            bridge.SetActive(isBridgeActive);
        }
        else
        {
            Debug.LogWarning("No bridge object assigned!");
        }
    }
}