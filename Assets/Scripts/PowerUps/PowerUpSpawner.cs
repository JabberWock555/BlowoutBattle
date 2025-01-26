using System;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private BoxCollider2D p1SpawnArea;
    [SerializeField] private BoxCollider2D p2SpawnArea;

    [SerializeField] private GameObject[] powerUps;




    private float spawnTimer;
    private int spawnPlayerIndex;


    private void Start()
    {
        spawnTimer = spawnInterval;
        spawnPlayerIndex = UnityEngine.Random.Range(1, 3);
    }

    private void Update()
    {
        SpawnCountdown();
    }

    private void SpawnCountdown()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        var area = spawnPlayerIndex == 1 ? p1SpawnArea : p2SpawnArea;

        Vector2 spawnPoint = new Vector2(
            UnityEngine.Random.Range(area.bounds.min.x, area.bounds.max.x),
            UnityEngine.Random.Range(area.bounds.min.y, area.bounds.max.y)
        );

        int random = 0; //UnityEngine.Random.Range(0, powerUps.Length);
        powerUps[random].transform.position = spawnPoint;

        // Toggle spawnPlayerIndex
        spawnPlayerIndex = spawnPlayerIndex == 1 ? 2 : 1;
    }
}
