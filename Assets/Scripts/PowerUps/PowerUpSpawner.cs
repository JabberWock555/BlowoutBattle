using System;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private BoxCollider2D p1SpawnArea;
    [SerializeField] private BoxCollider2D p2SpawnArea;
    
    [SerializeField] private GameObject bonusPointPrefab;
    [SerializeField] private GameObject freezePrefab;
    [SerializeField] private GameObject speedUpPrefab;
    
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
        var prefabs = new GameObject[] { bonusPointPrefab, freezePrefab, speedUpPrefab };
        var toSpawn = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
        Instantiate(toSpawn, spawnPoint, Quaternion.identity);
        
        // Toggle spawnPlayerIndex
        spawnPlayerIndex = spawnPlayerIndex == 1 ? 2 : 1;
    }
}
