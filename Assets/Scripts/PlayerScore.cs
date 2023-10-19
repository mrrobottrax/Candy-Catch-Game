using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScore : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Candy candy;
        if (collision.gameObject.TryGetComponent<Candy>(out candy))
        {
            GameManager.Singleton.AddScore(candy.GetScriptableObject().pointValue);

            Destroy(collision.gameObject);
        }
    }
}
