using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int player1Score { get; private set; }
    public int player2Score { get; private set; }

    public UIManager uiManager { get; private set; }

    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                UnpauseGame();
            }
            else PauseGame();
        }
    }

    public void UpdateScore(int playerNumber, int scoreDifference)
    {
        switch (playerNumber)
        {
            case 1:
                player1Score += scoreDifference;
                break;
            case 2:
                player2Score += scoreDifference;
                break;
        }
        uiManager.SetScoreText(playerNumber, scoreDifference);
    }

    private static bool _isGamePaused = false;
    public void PauseGame()
    {
        if (_isGamePaused)
            return;

        _isGamePaused = true;
        Time.timeScale = 0;
        uiManager.PauseMenuActive(true);
    }

    public void UnpauseGame()
    {
        if (!_isGamePaused)
            return;

        _isGamePaused = false;
        Time.timeScale = 1;
        uiManager.PauseMenuActive(false);
    }

}
