using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxBounce = 3;
    public int MaxBounce => maxBounce;
    private int bounceCounter;
    
    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        bounceCounter = maxBounce;
    }

    private void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                UnpauseGame();
            }
            else PauseGame();
        }*/
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

    public void RemoveOneBounce()
    {
        bounceCounter--;
        UIManager.Instance.RemoveOneBubbleIcon();
    }

    public void ResetBounceCounter()
    {
        bounceCounter = maxBounce;
        UIManager.Instance.AddMaxToBubbleDisplay();
    }
    

    private static bool _isGamePaused = false;
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
