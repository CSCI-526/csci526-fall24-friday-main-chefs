using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : BulletBase
{
    void Start()
    {
        // You can redefine various attributes already defined by the parent class here.
        // e.g., bulletSpeed, bulletLifeTime, calories
        foodType = FoodType.Fire;
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
    }
}
