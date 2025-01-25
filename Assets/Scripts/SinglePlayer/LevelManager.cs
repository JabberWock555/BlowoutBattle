using SABI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BaseLevel[] levels;
    [SerializeField] private int currentLevelIndex = 0;

    private BaseLevel currentLevel;


    private void SpawnLevel()
    {
        currentLevel = Instantiate(levels[currentLevelIndex], transform);
        currentLevel.gameObject.SetActive(true);
    }

    private void Start()
    {
        currentLevelIndex = 0;
        this.DelayedExecution(4f, () => SpawnLevel());
    }

    public void NextLevel()
    {
        Destroy(currentLevel.gameObject);
        currentLevelIndex++;
        if (currentLevelIndex >= levels.Length)
        {
            currentLevelIndex = 0;
        }


        SpawnLevel();
    }

    public void RestartLevel()
    {
        Destroy(levels[currentLevelIndex].gameObject);
        SpawnLevel();
    }
}
