using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    
    int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Candy candy;
        if (collision.gameObject.TryGetComponent<Candy>(out candy))
        {
            score += candy.GetScriptableObject().pointValue;
            scoreText.text = $"Score: {score}";

            Destroy(collision.gameObject);
        }
    }
}
