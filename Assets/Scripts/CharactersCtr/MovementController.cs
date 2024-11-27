using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;                  // Movement speed
    public bool isMovementReversed;             // Flag to check if movement is reversed
    private float reversalTimeLeft;             // Time remaining for reversed movement
    public bool isFrozen;             // Flag to check if movement is reversed
    private float freezeTimeLeft;
    public float temp;
    private Rigidbody2D rb;                     // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component when the game starts
        rb = GetComponent<Rigidbody2D>();
        temp = speed;
    }

    void Update()
    {
        // Get input from player
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Handle reversed movement timer
        if (isMovementReversed)
        {
            reversalTimeLeft -= Time.deltaTime;
            if (reversalTimeLeft <= 0)
            {
                isMovementReversed = false;
            }
            // Reverse the movement direction
            movement *= -1;
        }

        if (isFrozen)
        {
            freezeTimeLeft -= Time.deltaTime;
            if (freezeTimeLeft <= 0)
            {
                isFrozen = false;
                speed = temp;
            }
        }

        // Apply movement if there is input
        if (movement.sqrMagnitude > 0.01f)
        {
            rb.velocity = movement * speed;
        }
        else
        {
            // Stop movement when there is no input
            rb.velocity = Vector2.zero;
        }
    }

    public void ReverseMovement(float duration)
    {
        // Set reversed movement state and duration
        isMovementReversed = true;
        reversalTimeLeft = duration;
    }

    public void freezeEffect(float duration, float freezeSpeed)
    {
        isFrozen = true;
        freezeTimeLeft = duration;
        speed = freezeSpeed;
    }
}
