using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CoOpManager : MonoSingletonGeneric<CoOpManager>
{
    public Action<BasePowerUp> activatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public Action<BasePowerUp> deactivatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public bool isPowerUPActive = false;


    [FormerlySerializedAs("bubbleSpawnner")] [SerializeField] BubbleSpawner bubbleSpawner;

    public int player1Score = 0;
    public int player2Score = 0;
    public string player1Name;
    public string player2Name;


    public void SpawnBubble(int point)
    {
        if (bubbleSpawner == null)
        {
            bubbleSpawner = GetComponentInChildren<BubbleSpawner>();
        }

        bubbleSpawner.SpawnBubble(point);
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

    internal void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
    }


}
