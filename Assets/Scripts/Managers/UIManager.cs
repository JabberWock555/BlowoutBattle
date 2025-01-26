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
    public SinglePlayerUI singlePlayerUI;
    public GameOverPanelHandler gameOverPanelHandler;
    public void EndGame(int winnerIndex)
    {
        gameEndText.text = $"Player {winnerIndex} wins!";
        gameEndCanvas.gameObject.SetActive(true);
    }

    public void PauseMenuActive(bool isActive)
    {
        pauseMenuPanel.gameObject.SetActive(isActive);
    }

    #region Testing

    [ContextMenu("end")]
    public void endtest()
    {
        EndGame(2);
    }

    #endregion
}
