using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candy", menuName = "ScriptableObjects/Candy", order = 1)]
public class CandyScriptableObject : ScriptableObject
{
    public Sprite sprite;

    public float spawnWeight = 1;

    public float fallSpeed = 5;

    public int pointValue = 1;
}
