using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public enum FoodType { Regular, Mentos, Soda, Fire, Ice }; // Define different food types
    public FoodType foodType;  // Store the type of food
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 2f;
    public float calories = 10f;
    public static Dictionary<string, int> counter = new Dictionary<string, int>();
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

        //Debug.Log("BulletBase Start");
        string stringType = foodType.ToString().ToLower();

        if (counter.ContainsKey(stringType))
        {
            //Debug.Log("Counter contains key: " + stringType);
            //Debug.Log("Incrementing key: " + counter[stringType]);
            counter[stringType] += 1;
        }
        else
        {
            //Debug.Log("Counter does not contain key: " + stringType);
            //Debug.Log("Adding key: " + stringType);
            counter[stringType] = 1;
        }
    }

    protected virtual void Update()
    {
        // Check if the bullet should be destroyed based on its lifetime
        if(bulletLifeTime < 0)
        {
            // Infinity
            return;
        }

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
