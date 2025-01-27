using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private Canvas gameEndCanvas;
    [SerializeField] private GameObject pauseMenuPanel;
    public CountDownTimerUI countDownTimerUI;

    public CoOpUIPanelHandler coOpUIPanelHandler;
    public MainMenuUIPanelHandler mainMenuUIPanelHandler;
    public GameOverPanelHandler gameOverPanelHandler;


    public int maxGoals;
    public void EndGame(int winnerIndex)
    {
        gameEndText.text = $"Player {winnerIndex} wins!";
        gameEndCanvas.gameObject.SetActive(true);
    }

    public void PauseMenuActive(bool isActive)
    {
        pauseMenuPanel.gameObject.SetActive(isActive);
    }


    public void ResetPanelsForMainMenu()
    {
        coOpUIPanelHandler.gameObject.SetActive(false);
        gameOverPanelHandler.gameObject.SetActive(false);
        mainMenuUIPanelHandler.gameObject.SetActive(true);
        mainMenuUIPanelHandler.playMenuUI.SetActive(true);
        ResetPlayerData();
    }

    public void ResetPanelsForGameOver()
    {
        mainMenuUIPanelHandler.gameObject.SetActive(false);
        coOpUIPanelHandler.gameObject.SetActive(false);
        ResetPlayerData();
    }

    public void ResetPanelsForGamePlay()
    {
        mainMenuUIPanelHandler.gameObject.SetActive(false);
        gameOverPanelHandler.gameObject.SetActive(false);
        ResetPlayerData();


    }

    public void ResetPlayerData()
    {
        coOpUIPanelHandler.player1UI.playerScore.text = 0.ToString();
        coOpUIPanelHandler.player2UI.playerScore.text = 0.ToString();
        coOpUIPanelHandler.player1UI.chargeBar.fillAmount = 1f;
        coOpUIPanelHandler.player2UI.chargeBar.fillAmount = 1f;
    }

    #region Testing

    [ContextMenu("end")]
    public void endtest()
    {
        EndGame(2);
    }

    #endregion
}
