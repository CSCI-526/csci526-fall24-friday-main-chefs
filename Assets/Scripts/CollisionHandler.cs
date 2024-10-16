using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private HealthController healthController ;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object collides with an enemy or player, apply damage accordingly
        if (collision.gameObject.tag == "Enemy" && healthController.isPlayer)
        {
            // Call the TakeDamage method in HealthController and pass the bullet's calories (damage)
            float damage = collision.gameObject.GetComponent<BulletBehaviour>().calories;
            healthController.TakeDamage(damage, collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "Player" && !healthController.isPlayer)
        {
            // Call the TakeDamage method in HealthController and pass the bullet's calories (damage)
            float damage = collision.gameObject.GetComponent<BulletBehaviour>().calories;
            healthController.TakeDamage(damage, collision.gameObject.tag);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/* When ever we are calling takeDamage here we also need to pass the tag of bullet to decide the effect on player and enemy body.
healthController.TakeDamage(damage, collision.gameObject.tag);
*/