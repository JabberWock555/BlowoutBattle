using UnityEngine;

public class BubbleSpawnner : MonoBehaviour
{
    [SerializeField] Bubble bubblePrefab;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnForce = 5f;


    public void SpawnBubble(int point)
    {
        Bubble bubble = Instantiate(bubblePrefab, spawnPoints[point].position, Quaternion.identity);
        Vector3 dir = spawnPoints[point].position - transform.position;

        bubble.ApplyAirForce(dir, spawnForce);

    }



}
