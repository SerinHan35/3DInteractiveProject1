using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed = 10f;

    // Stretch: multiplier for increasing force (e.g. sprint)
    public float sprintMultiplier = 2f;
    public float currentMultiplier = 1f;

    // Optional: limit max speed so physics doesn't run away
    public float maxSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Read input using Unity's axes (works for WASD / arrow keys / controllers)
        float h = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Set multiplier (hold LeftShift to sprint)
        currentMultiplier = Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f;

        // Build movement direction in local XZ plane
        Vector3 inputDir = new Vector3(h, 0f, v).normalized;

        if (inputDir != Vector3.zero)
        {
            // Apply force in world-space forward/right
            rb.AddForce(inputDir * speed * currentMultiplier, ForceMode.Acceleration);
        }

        // Optional: clamp velocity so physics stays stable
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}