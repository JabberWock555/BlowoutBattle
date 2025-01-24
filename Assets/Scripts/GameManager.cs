using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    
    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
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
        UIManager.Instance.SetScoreText(playerNumber, scoreDifference);
    }
}
