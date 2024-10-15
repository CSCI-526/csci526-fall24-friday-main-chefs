using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 2f;
    public float calories = 10f;
    private Rigidbody2D rb;
    private float lifeTime = 0;

    public void setVelocity(Vector2 direction)
    {
        rb.velocity = direction * bulletSpeed;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Mirror")
        {
            // Reflect the bullet using the normal of the surface it hit
            Vector2 reflectDirection = Vector2.Reflect(rb.velocity.normalized, collision.transform.up); // Using the up vector of the mirror surface
            setVelocity(reflectDirection);  // Set the new direction
        }
        else
        {
            // Destroy the bullet if it hits anything else
            Destroy(gameObject);
        }
    }

    
}
