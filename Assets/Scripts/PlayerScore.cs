using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Candy candy;
        if (collision.gameObject.TryGetComponent<Candy>(out candy))
        {
            GameManager.Singleton.score += candy.GetScriptableObject().pointValue;
            scoreText.text = $"Score: {GameManager.Singleton.score}";

            Destroy(collision.gameObject);
        }
    }
}
