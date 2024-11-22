using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : BulletBase
{
    // Start is called before the first frame update
    void Start()
    {
        foodType = FoodType.Ice;
    }

    public override void SetTrajectory(Vector2 direction)
    {
        // Implement bullet's unique trajectory in this area
        // BasicTrajectory is just a simplest template
        BasicTrajectory(direction);
    }
    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
