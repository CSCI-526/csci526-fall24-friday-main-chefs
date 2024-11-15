using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Header("Black Hole Properties")]
    [SerializeField] private float pulseMinScale = 0.8f;
    [SerializeField] private float pulseMaxScale = 1.2f;
    [SerializeField] private float pulseSpeed = 2f;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Configure Rigidbody2D to stay in place
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll; // Freeze position and rotation
    }
    
    private void Update()
    {
        // Create a pulsing effect
        float scale = Mathf.Lerp(pulseMinScale, pulseMaxScale, 
            (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f);
        transform.localScale = new Vector3(scale, scale, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}