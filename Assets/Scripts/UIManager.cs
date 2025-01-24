using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    [SerializeField] private RectTransform player1FuelBar;
    [SerializeField] private RectTransform player2FuelBar;
    
    public static UIManager Instance;

    private void Start()
    {
        Instance = this;
    }
    
    public void SetFuelMeter(int playerNumber, int fuelPercent)
    {
        float parentWidth = player1FuelBar.parent.GetComponent<RectTransform>().rect.width;
        float targetWidth = fuelPercent / 100f * parentWidth;

        switch (playerNumber)
        {
            case 1:
                player1FuelBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
                break;
            case 2:
                player2FuelBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
                break;
        }
    }
    
    
    public void SetScoreText(int playerNumber, int scoreDifference)
    {
        GameManager gameManager = GameManager.Instance;  
        switch (playerNumber)
        {
            case 1:
                player1ScoreText.text = gameManager.player1Score.ToString();
                break;
            case 2:
                player2ScoreText.text = gameManager.player2Score.ToString();
                break;
        }
    }
}
