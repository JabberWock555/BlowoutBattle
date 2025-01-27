using SABI;
using UnityEngine;

public class BubbleSpawnner : MonoBehaviour
{
    [SerializeField] Bubble bubblePrefab;
    [SerializeField] Transform spriteObject;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnForce = 5f;

    Bubble bubble;
    public void SpawnBubble(int point)
    {
        if (bubble != null)
        {
            bubble.gameObject.SetActive(false);
        }

        Vector3 dir = (spawnPoints[point].position - spriteObject.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f; // Apply the rotation to the

        spriteObject.rotation = Quaternion.Euler(0, 0, angle);


        this.DelayedExecution(2f, () =>
        {
            if (bubble == null)
                bubble = Instantiate(bubblePrefab, spawnPoints[point].position, Quaternion.identity);

            bubble.gameObject.SetActive(true);

            bubble.transform.position = spawnPoints[point].position;


            bubble.ApplyAirForce(dir, spawnForce);

        });

    }




}
