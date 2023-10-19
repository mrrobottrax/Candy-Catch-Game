using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawn : MonoBehaviour
{
    [SerializeField] GameObject candyPrefab;
    [SerializeField] CandyScriptableObject[] candies;

    [SerializeField] float minSpawnTime = 1;
    [SerializeField] float maxSpawnTime = 3;

    [SerializeField] int maxCandiesSpawned = 15;

    [SerializeField] float minX = -8;
    [SerializeField] float maxX = 8;

    [SerializeField] float startY = 8;

    int candiesSpawned = 0;

    float totalCandyWeights = 0;

    private void Awake()
    {
        totalCandyWeights = 0;
        foreach (CandyScriptableObject candy in candies)
        {
            totalCandyWeights += candy.spawnWeight;
        }
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        candiesSpawned = 0;

        StartCoroutine(ICandySpawnTimer());
    }

    private IEnumerator ICandySpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

        SpawnCandy();

        if (candiesSpawned < maxCandiesSpawned)
        {
            StartCoroutine(ICandySpawnTimer());
        }
    }

    private void SpawnCandy()
    {
        // weighted random
        int index = 0;
        float sum = totalCandyWeights;
        for (int i = 0; i < candies.Length; ++i)
        {
            float value = Random.Range(0.0f, 1.0f) * totalCandyWeights;

            sum -= candies[i].spawnWeight;
            if (value >= sum)
            {
                index = i;
                break;
            }
        }

        float xPos = Random.Range(minX, maxX);

        GameObject candy =  Instantiate(candyPrefab, new Vector3(xPos, startY, 0), Quaternion.identity);
        candy.GetComponent<SpriteRenderer>().sprite = candies[index].sprite;
        candy.GetComponent<Candy>().SetFallSpeed(candies[index].fallSpeed);

        ++candiesSpawned;
    }
}
