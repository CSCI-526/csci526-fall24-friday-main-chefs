using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    public bool isBurned;             // Flag to check if movement is reversed
    private float burnTimeLeft;
    public float temp;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        if (isPlayer)
        {
            healthNum.text = ((int)currentHealth).ToString();
        }
        temp = healthDecreaseRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && isPlayer)
        {
            EatBullets(-3);
        }
        // Implement Collison detection here and change the health point accordingly
        if (isBurned)
        {
            burnTimeLeft -= Time.deltaTime;
            if (burnTimeLeft <= 0)
            {
                isBurned = false;
                healthDecreaseRate = temp;
            }
        }

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            if (isPlayer)
            {
                Debug.Log("currentHealth Death");
                gameManager.gameOver("On a diet   \nOh! Overdid it  ", false);
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
            healthNum.text = ((int)currentHealth).ToString() + "%";
        }

        UpdatePlayerScale();
    }

    public void EatBullets(float calories)
    {
        currentHealth += calories;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;   // Visual changes can be added here for when current health exceeds maxhealth
            isDead = true;
            if (isPlayer)
            {
                gameManager.gameOver("Overloaded!\nI  ll skip dessert...", false);
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
        if (maxSize > maxSizeUpperBound)
        {
            maxSize = maxSizeUpperBound;
        }
        if (maxSize > maxSizeLowerBound)
        {
            maxSize -= maxSizeDecreaseRate * Time.deltaTime;
            //float current = maxSize;
            //maxSize = Mathf.Lerp(1.5f, current, 0.95f); 
        }

        // Normalize health to a value between 0.5 and 1.5 for scaling
        float healthPercentage = (float)currentHealth / maxHealth;
        float newScale = Mathf.Lerp(minSize, maxSize, healthPercentage);

        // Update the player's scale based on current health
        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    public void burnEffect(float duration, float burnRate)
    {
        isBurned = true;
        burnTimeLeft = duration;
        healthDecreaseRate = burnRate;
    }

    public void forkEffect(float forkDamage)
    {
        currentHealth -= forkDamage;
    }

}
