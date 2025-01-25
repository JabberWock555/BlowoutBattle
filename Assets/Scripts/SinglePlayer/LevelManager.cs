using SABI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private BaseLevel[] levels;
    [SerializeField] private int currentLevelIndex = 0;

    private BaseLevel currentLevel;
    private UIManager uiManager;
    private BaseBlowerController playerController;


    private void SpawnLevel()
    {
        currentLevel = Instantiate(levels[currentLevelIndex], transform);
        playerController.gameObject.SetActive(true);
        currentLevel.gameObject.SetActive(true);
    }

    private void Start()
    {
        uiManager = UIManager.Instance;
        playerController = GameManager.Instance.SpawnPlayer1();
        playerController.gameObject.SetActive(false);
        FindAnyObjectByType<CameraFollower>().SetTarget(playerController.transform);


        currentLevelIndex = 0;
        StartLevel();
    }

    private void StartLevel()
    {
        StartCoroutine(uiManager.singlePlayerUI.StartCountDown());
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


        StartLevel();
    }

    public void RestartLevel()
    {
        Destroy(levels[currentLevelIndex].gameObject);
        SpawnLevel();
    }
}
