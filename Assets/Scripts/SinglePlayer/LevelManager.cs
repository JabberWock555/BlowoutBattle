using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BaseLevel[] levels;
    [SerializeField] private int currentLevelIndex = 0;


    private void SpawnLevel()
    {
        levels[currentLevelIndex].gameObject.SetActive(true);
    }

    private void Start()
    {
        currentLevelIndex = 0;
        SpawnLevel();
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex >= levels.Length)
        {
            currentLevelIndex = 0;
        }
        Destroy(levels[currentLevelIndex].gameObject);
        SpawnLevel();
    }

    public void RestartLevel()
    {
        Destroy(levels[currentLevelIndex].gameObject);
        SpawnLevel();
    }




}
