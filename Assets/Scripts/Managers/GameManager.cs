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
    [SerializeField] private BaseBlowerController player1Controller;
    [SerializeField] private BaseBlowerController player2Controller;

    public GameMode gameState { get; private set; }
    public UIManager uiManager;


    private void Start()
    {
        //uiManager = UIManager.Instance;
    }

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

    public BaseBlowerController SpawnPlayer1()
    {
        return Instantiate(player1Controller);
    }

    public BaseBlowerController SpawnPlayer2()
    {
        return Instantiate(player2Controller);
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
