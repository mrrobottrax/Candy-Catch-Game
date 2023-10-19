using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public int score;

    [SerializeField] GameObject endScreen;
    [SerializeField] TMP_Text endScoreText;

    private void Awake()
    {
        Singleton = this;
        endScreen.SetActive(false);
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        endScoreText.text = $"Score {score}";
    }

    public void RestartGame()
    {

    }
}
