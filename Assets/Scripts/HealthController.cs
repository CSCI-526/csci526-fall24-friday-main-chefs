using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public bool isPlayer;

    public GameManagerScript gameManager; 
    public float maxHealth = 100f; 
    public float currentHealth = 50f; 

    public float maxSize = 1.5f; // Maximum scale of the player
    public float minSize = 0.5f; // Minimum scale of the player

    public float healthDecreaseRate = 0.5f; // used for decreasing health with respect to time

    public healthBar healthBar;  
    private bool isDead; 


    // Variables for isExploding 
    private bool isExploding = false; // Track if the player is in an "exploding" state
    private float explosionTimer = 0f; // Timer for the explosion effect

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Implement Collison detection here and change the health point accordingly
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true ;
            if(isPlayer)
            {
                gameManager.gameOver("You lose!");
            }
            else
            {
                Destroy(gameObject);
                gameManager.gameOver("You win!");
            }
            Debug.Log("Dead");
        }
       
        currentHealth -= healthDecreaseRate * Time.deltaTime; 
        healthBar.SetHealth(currentHealth);

        UpdatePlayerScale();
    }

   

    public void TakeDamage(float damage, string bulletTag )
    {
        currentHealth += damage;

        // This is code after we have implemented bulletTag, we have to pass that in TakeDamage Function to detect mentos and soda
        if (bulletTag == "mentos" || bulletTag == "soda")
        {
            TriggerExplosionEffect();
        }


        if (currentHealth> maxHealth)
        {
            currentHealth = maxHealth;   // Visual changes can be added here for when current health exceeds maxhealth
            isDead = true ;
            if (isPlayer)
            {
                gameManager.gameOver("You lose!");
            }
            else
            {
                Destroy(gameObject);
                gameManager.gameOver("You win!");
            }
            Debug.Log("Dead due to excess engergy");
        }
        else 
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds 
        }

        healthBar.SetHealth(currentHealth);
    }

    // For TriggerExplosionEffect
    void TriggerExplosionEffect()
    {
        isExploding = true;
        explosionTimer = 0f; // Reset the timer when the explosion is triggered
    }

    void UpdatePlayerScale()
    {
        // For effect on player and enemy for deformation when they are hit by mentos and soda bullet
         if (isExploding)
        {
            // Increase the explosion timer
            explosionTimer += Time.deltaTime;

            // Generate dynamic scaling using Perlin Noise for an uneven bulging effect
            float scaleX = Mathf.Lerp(minSize, maxSize * 2, Mathf.PerlinNoise(explosionTimer, 0f));
            float scaleY = Mathf.Lerp(minSize, maxSize * 2, Mathf.PerlinNoise(0f, explosionTimer));

            // Update the player's scale based on dynamic Perlin Noise values
            transform.localScale = new Vector3(scaleX, scaleY, 1);

            // Stop the explosion effect after a certain time
            if (explosionTimer > 2f) // Change duration as needed
            {
                isExploding = false;
            }
        }
        else 
        {
        // Normalize health to a value between 0.5 and 1.5 for scaling
        float healthPercentage = (float)currentHealth/maxHealth; 
        float newScale = Mathf.Lerp(minSize, maxSize, healthPercentage);

        // Update the player's scale based on current health
        transform.localScale = new Vector3 (newScale, newScale, 1);

        }

       
    }

}
