using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public enum FoodType {Regular, Mentos, Soda}; // Define different food types
    public FoodType foodType;  // Store the type of food
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 2f;
    public float calories = 10f;
    protected Rigidbody2D rb;
    protected float lifeTime = 0;

    // Basic trajectory of the bullet
    public virtual void BasicTrajectory(Vector2 direction)
    {
        rb.velocity = direction * bulletSpeed;
    }

    // Abstract method (Different movement trajectories for each type of bullet)
    public abstract void SetTrajectory(Vector2 direction);

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // Check if the bullet should be destroyed based on its lifetime
        lifeTime += Time.deltaTime;
        // Debug.Log(lifeTime);
        if (lifeTime > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    // Destroy the bullet when it collides with something
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
