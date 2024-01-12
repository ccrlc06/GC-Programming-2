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

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }

        transform.position += velocity * moveSpeed * dt;
    }
}
