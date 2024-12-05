using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : BulletBase
{
    public GameObject target;
    public float burnDuration = 3f;
    public float burnRate = 5f;
    void Start()
    {
        // You can redefine various attributes already defined by the parent class here.
        // e.g., bulletSpeed, bulletLifeTime, calories
        foodType = FoodType.Fire;
        target = GameObject.Find("Player");
    }

    // Override the SetTrajectory method
    public override void SetTrajectory(Vector2 direction)
    {
        // Implement bullet's unique trajectory in this area
        // BasicTrajectory is just a simplest template
        BasicTrajectory(direction);
        rb.velocity = direction * bulletSpeed;  
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        HealthController healthController = target.GetComponent<HealthController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            healthController.burnEffect(burnDuration, burnRate);
        }
    }
}
