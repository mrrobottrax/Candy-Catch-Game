using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    [SerializeField] GameObject endScreen;

    private void Awake()
    {
        Singleton = this;
        endScreen.SetActive(false);
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }

    public void RestartGame()
    {

    }
}
