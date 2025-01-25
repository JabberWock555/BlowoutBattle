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



    private bool _isGamePaused;

    public void PauseGame()
    {
        if (_isGamePaused)
            return;

        _isGamePaused = true;
        Time.timeScale = 0;
        UIManager.Instance.PauseMenuActive(true);
    }

    public void UnpauseGame()
    {
        if (!_isGamePaused)
            return;

        _isGamePaused = false;
        Time.timeScale = 1;
        UIManager.Instance.PauseMenuActive(false);
    }

}
