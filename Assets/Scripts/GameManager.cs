using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    MAINMENU,
    Coop,
    SinglePlayer,
}

public class GameManager : MonoSingletonGeneric<GameManager>
{

    public GameMode gameState { get; private set; }

    public UIManager uiManager;


    public void SetGameState(GameMode gameMode)
    {
        gameState = gameMode;
        int sceneIndex = 0;
        switch (gameMode)
        {
            case GameMode.MAINMENU:
                sceneIndex = 0;
                break;
            case GameMode.Coop:
                sceneIndex = 1;
                break;
            case GameMode.SinglePlayer:
                sceneIndex = 2;
                break;
        }

        SceneManager.LoadScene(sceneIndex);
    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Escape))
         {
             if (_isGamePaused)
             {
                 UnpauseGame();
             }
             else PauseGame();
         }*/
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
