using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Candy : MonoBehaviour
{
    CandyScriptableObject candyScriptableObject;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetScriptableObject(CandyScriptableObject candyScriptableObject)
    {
        this.candyScriptableObject = candyScriptableObject;
        rb.velocity = new Vector2(0, -candyScriptableObject.fallSpeed);
    }

    public CandyScriptableObject GetScriptableObject()
    {
        return candyScriptableObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CandyKiller"))
        {
            Destroy(gameObject);
        }
    }
}
