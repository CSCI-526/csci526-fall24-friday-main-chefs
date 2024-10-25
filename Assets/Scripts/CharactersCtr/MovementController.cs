using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isJumping = false;
    public float speed = 5.0f;
    public float jumpDuration = 3.0f;
    public float jumpDistance = 10.0f;
    public AnimationCurveAsset jumpCurveAsset;

    private float jumpStartTime;
    private float initialY;
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private AnimationCurve jumpCurve;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        jumpCurve = jumpCurveAsset.curve;
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (movement.sqrMagnitude > 0.01f)
            {
                rb.velocity = movement * speed;
            }
        }
        else
        {
            JumpMotion();
        }
    }

    private void Jump()
    {
        cc.enabled = false;
        initialY = transform.position.y;
        jumpStartTime = Time.time;
        isJumping = true;
    }

    private void JumpMotion()
    {
        float elapsedTime = Time.time - jumpStartTime;
        if (elapsedTime < jumpDuration)
        {
            float jumpHeight = jumpCurve.Evaluate(elapsedTime / jumpDuration);
            float newX = transform.position.x + (jumpDistance / jumpDuration) * Time.deltaTime;
            float newY = initialY + jumpHeight;
            transform.position = new Vector2(newX, newY);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, initialY);
            isJumping = false;
            cc.enabled = true;
        }
    }
}
