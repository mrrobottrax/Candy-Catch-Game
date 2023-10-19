using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 12.0f;
    [SerializeField] float acceleration = 120.0f;
    [SerializeField] float friction = 40.0f;

    private InputAction moveAction;
    private Rigidbody2D rb;

    [SerializeField] float minX = -9;
    [SerializeField] float maxX = 9;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.isKinematic = true;
    }

    private void Start()
    {
        moveAction = Controls.Singleton.IngameActionMap.FindAction("Move", true);
    }

    private void Update()
    {
        float moveDir = moveAction.ReadValue<float>();

        float vel = rb.velocity.x;

        vel = Friction(vel, friction, Time.deltaTime);
        vel = Accelerate(vel, speed, acceleration * moveDir, Time.deltaTime);

        // stop at sides of screen
        Vector2 pos = rb.position + Time.fixedDeltaTime * vel * Vector2.right;
        if (pos.x < minX)
        {
            pos.x = minX;
            rb.MovePosition(pos);
            vel = 0;
        }
        else if (pos.x > maxX)
        {
            pos.x = maxX;
            rb.MovePosition(pos);
            vel = 0;
        }

        rb.velocity = vel * Vector2.right;
    }

    private float Accelerate(float velocity, float maxVelocity, float acceleration, float deltaT)
    {
        velocity += acceleration * deltaT;

        velocity = Mathf.Clamp(velocity, -maxVelocity, maxVelocity);

        return velocity;
    }

    private float Friction(float velocity, float friction, float deltaT)
    {
        if (velocity == 0)
            return 0;

        float drop = friction * deltaT;

        // apply friction against move direction
        if (velocity > 0)
        {
            velocity -= drop;

            if (velocity < 0)
                velocity = 0;
        }
        else
        {
            velocity += drop;

            if (velocity > 0)
                velocity = 0;
        }


        return velocity;
    }
}
