using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour


{
    public float acceleration = 5f;  // Acceleration value
    public float maxSpeed = 10f;    // Maximum speed value

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 currentVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal and vertical input values
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Calculate movement vector based on input
        movement = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        // Calculate target velocity based on acceleration
        Vector2 targetVelocity = movement * maxSpeed;
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Apply the calculated velocity to the rigidbody
        rb.velocity = currentVelocity;
    }
}
