using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1to2 : MonoBehaviour
{
    public float newHealthDecreaseRate = 1.0f;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();
            
            if (playerHealth != null)
            {
                playerHealth.healthDecreaseRate = newHealthDecreaseRate;
                playerHealth.temp = newHealthDecreaseRate;  
            }

            this.gameObject.SetActive(false);
        }
    }
}