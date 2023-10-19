using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 0.3f;
    [SerializeField] float _acceleration = 3.0f;
    [SerializeField] float _friction = 1.0f;

    private InputAction _moveAction;
    private Rigidbody2D _rb;

    [SerializeField] float minX = -9;
    [SerializeField] float maxX = 9;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.isKinematic = true;
    }

    private void Start()
    {
        _moveAction = Controls.Singleton.IngameActionMap.FindAction("Move", true);
    }

    private void Update()
    {
        float moveDir = _moveAction.ReadValue<float>();

        float vel = _rb.velocity.x;

        vel = Friction(vel, _friction, Time.deltaTime);
        vel = Accelerate(vel, _speed, _acceleration * moveDir, Time.deltaTime);

        _rb.velocity = new Vector2(vel, 0);

        Vector2 newPos = _rb.position + Vector2.right * _rb.velocity.x;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

        _rb.MovePosition(newPos);
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
