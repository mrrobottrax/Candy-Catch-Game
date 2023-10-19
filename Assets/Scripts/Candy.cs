using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Candy : MonoBehaviour
{
    [SerializeField] float fallSpeed = 10;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -fallSpeed);
    }

    public void SetFallSpeed(float speed)
    {
        fallSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CandyKiller"))
        {
            Destroy(gameObject);
        }
    }
}
