using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public bool isPlayer;

    public GameManagerScript gameManager; 
    public float maxHealth = 100f; 
    public float currentHealth = 50f;

    public float maxSizeUpperBound = 7.5f;
    public float maxSizeLowerBound = 1.5f;
    public float maxSize = 1.5f; // Maximum scale of the player
    public float minSize = 0.5f; // Minimum scale of the player
    public float maxSizeDecreaseRate = 0.5f; // used for increasing max size with respect to time

    public float healthDecreaseRate = 0.5f; // used for decreasing health with respect to time

    public healthBar healthBar;

    public TextMeshProUGUI healthNum;
    private bool isDead; 

    private SpriteFlash spriteFlash ; // Reference to SpriteFlash script
    private bool isFading = false ; 

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        if(isPlayer) 
        {
            healthNum.text = ((int)currentHealth).ToString();
        }        

        spriteFlash = GetComponent<SpriteFlash>(); 
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
                gameManager.gameOver("On a diet�� \nOh! Overdid it��", false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
       
        currentHealth -= healthDecreaseRate * Time.deltaTime; 
        healthBar.SetHealth(currentHealth);
        if (isPlayer)
        {
            healthNum.text = ((int)currentHealth).ToString();
        }

        UpdatePlayerScale();
        CheckForHealthFade(); // Check if health is low for fade effect
    }

    public void EatBullets(float calories)
    {
        currentHealth += calories;

        if (currentHealth> maxHealth)
        {
            currentHealth = maxHealth;   // Visual changes can be added here for when current health exceeds maxhealth
            isDead = true ;
            if (isPlayer)
            {
                gameManager.gameOver("Overloaded!\nI��ll skip dessert...", false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else 
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays within bounds 
        }

        healthBar.SetHealth(currentHealth);
    }

    void UpdatePlayerScale()
    {
        if(maxSize > maxSizeUpperBound)
        {
            maxSize = maxSizeUpperBound;
        }
        if(maxSize > maxSizeLowerBound)
        {
            maxSize -= maxSizeDecreaseRate * Time.deltaTime; 
            //float current = maxSize;
            //maxSize = Mathf.Lerp(1.5f, current, 0.95f); 
        }

        // Normalize health to a value between 0.5 and 1.5 for scaling
        float healthPercentage = (float)currentHealth/maxHealth; 
        float newScale = Mathf.Lerp(minSize, maxSize, healthPercentage);

        // Update the player's scale based on current health
        transform.localScale = new Vector3 (newScale, newScale, 1);
    }

   private void CheckForHealthFade()
    {
        if ((currentHealth <= 25 || currentHealth >= 75) && !isFading)
        {
            isFading = true;
            spriteFlash.StartFading(1.5f, 0.2f, 3); // Fading effect with transparency only
        }
        else if (currentHealth > 25 && currentHealth < 75 && isFading)
        {
            isFading = false;
            spriteFlash.ResetColor(); // Reset color back to original when in safe range
        }
    }



}
