using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoSingletonGeneric<UIManager>
{
    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private Canvas gameEndCanvas;
    [SerializeField] private GameObject pauseMenuPanel;

    public MainMenuUIPanelHandler mainMenuUIPanelHandler;
    public CoOpUIPanelHandler coOpUIPanelHandler;
    public SinglePlayerUI singlePlayerUI;

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
