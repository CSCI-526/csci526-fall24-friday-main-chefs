using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullets : BulletBase
{
    public GameObject target;
    public float freezeDuration = 3f;
    public float freezeSpeed = 2.0f;
    void Start()
    {
        // You can redefine various attributes already defined by the parent class here.
        // e.g., bulletSpeed, bulletLifeTime, calories
        foodType = FoodType.Ice;
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
        MovementController movementController = target.GetComponent<MovementController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            movementController.freezeEffect(freezeDuration, freezeSpeed);
        }
    }
}
