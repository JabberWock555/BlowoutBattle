using System;
using UnityEngine;

public class CoOpManager : MonoSingletonGeneric<CoOpManager>
{
    public Action<BasePowerUp> activatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public Action<BasePowerUp> deactivatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public bool isPowerUPActive = false;


    [SerializeField] BubbleSpawnner bubbleSpawnner;

    public int player1Score = 0;
    public int player2Score = 0;
    public string player1Name;
    public string player2Name;


    public void SpawnBubble(int point)
    {
        if (bubbleSpawnner == null)
        {
            bubbleSpawnner = GetComponentInChildren<BubbleSpawnner>();
        }

        bubbleSpawnner.SpawnBubble(point);
    }


    public void SetPlayerNames(string p1, string p2)
    {
        player1Name = p1;
        player2Name = p2;
    }

    public void ActivateGameOverPanel()
    {
        GameManager.Instance.uiManager.gameOverPanelHandler.gameObject.SetActive(true);
        if (player1Score > player2Score)
        {

            GameManager.Instance.uiManager.gameOverPanelHandler.SetPlayerNameByID(player1Name);

        }
        else
        {
            GameManager.Instance.uiManager.gameOverPanelHandler.SetPlayerNameByID(player2Name);
        }


    }

}
