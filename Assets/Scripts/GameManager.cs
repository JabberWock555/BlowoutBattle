using System;
using UnityEngine;

public enum GameMode
{
    SinglePlayer,
    Coop
}

public class GameManager : MonoSingletonGeneric<GameManager>
{
    [SerializeField] private SceneManager sceneManager;
    public int player1Score { get; private set; }
    public int player2Score { get; private set; }

    public GameMode gameState { get; private set; }

    public void SetGameState(GameMode gameMode)
    {
        gameState = gameMode;

        switch (gameMode)
        {
            case GameMode.SinglePlayer:
                sceneManager.LoadSceneSolo("SinglePlayerScene");
                break;
            case GameMode.Coop:
                sceneManager.LoadSceneCoop("CoopScene");
                break;
        }
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

    private bool _isGamePaused;

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
