using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1to2 : MonoBehaviour
{
    public GameObject gate;
    public GameObject s1Enemy1;
    public GameObject s1Enemy2;
    public GameObject iceEnemy;
    public GameObject sodaEnemy;
    public GameObject mentoEnemy;
    public float newHealthDecreaseRate = 2.0f;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // disable the scripts of enemies in section 1
            if (s1Enemy1 != null)
            {
                s1Enemy1.GetComponent<ShootController>().enabled = false;
            }
            if (s1Enemy2 != null)
            {
                s1Enemy2.GetComponent<ShootController>().enabled = false;
            }

            // enable the scripts of enemies in section 2
            if (iceEnemy != null)
            {
                iceEnemy.GetComponent<EnemyMovement>().enabled = true;
                iceEnemy.GetComponent<ShootController>().enabled = true;
            }
            if (sodaEnemy != null)
            {
                sodaEnemy.GetComponent<ShootController>().enabled = true;
                sodaEnemy.GetComponent<EnemyMovement>().enabled = true;
            }
            if (mentoEnemy != null)
            {
                mentoEnemy.GetComponent<ShootController>().enabled = true;
                mentoEnemy.GetComponent<EnemyMovement>().enabled = true;
            }

            // decrease the player's energy bar
            HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.healthDecreaseRate = newHealthDecreaseRate;
                playerHealth.temp = newHealthDecreaseRate;  
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}