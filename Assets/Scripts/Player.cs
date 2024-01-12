using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 10.0f;    // How fast we move (10 units per second)
    float turnSpeed = 360.0f;   // How fast we turn (1 revolution per second)

    void Start()
    {
        
    }

    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, 0.0f, -turnSpeed * dt);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, 0.0f, turnSpeed * dt);
        }
        // The quaternion stores our rotation and the vector stores our forward direction.
        // We're using to seeing an arrow pointing along +x when rotation is 0, so we use Vector3.right
        // If we instead wanted to point vertically with a rotation of 0, then we use Vector3.up.
        //Vector3 direction = transform.rotation * Vector3.right;

        // The automatic way to do this is to use transform.right/up/forward:
        // If we want +x to be our "forward direction" we use transform.right
        // If we want +y to be our "forward direction" we use transform.up
        // If we want +z to be our "forward direction" we use transform.forward

        Vector3 forward = transform.right;
        Vector3 right = transform.up * -1.0f;
        Debug.DrawLine(transform.position, transform.position + forward * 10.0f, Color.red);
        Debug.DrawLine(transform.position, transform.position + right * 10.0f, Color.green);

        if (Input.GetKey(KeyCode.W))
        {
            velocity += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity -= forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity -= right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += right;
        }

        transform.position += velocity * moveSpeed * dt;
    }
}
