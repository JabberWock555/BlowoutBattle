using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    [SerializeField] private RectTransform player1FuelBar;
    [SerializeField] private RectTransform player2FuelBar;
    [SerializeField] private Image player1PowerupIcon;
    [SerializeField] private Image player2PowerupIcon;
    [SerializeField] private TextMeshProUGUI player1Name;
    [SerializeField] private TextMeshProUGUI player2Name;

    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private Canvas gameEndCanvas;
    [SerializeField] private GameObject pauseMenuPanel;

    [SerializeField] PowerupsSO powerupsSO;


    private void Start()
    {
        player1Name.text = SceneManager.Player1Name;
        player2Name.text = SceneManager.Player2Name;
    }

    public void SetFuelMeter(int playerNumber, float fuelPercent)
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

    public void SetPowerupIcon(int playerNumber, PowerupsSO.PowerupType powerupType)
    {
        PowerupsSO.Powerup currentPowerup = null;
        foreach (PowerupsSO.Powerup powerup in powerupsSO.powerupsArray)
        {
            if (powerup.type == powerupType)
            {
                currentPowerup = powerup;
            }
        }

        if (currentPowerup == null)
        {
            Debug.Log("Powerup not found");
            return;
        }

        switch (playerNumber)
        {
            case 1:
                player1PowerupIcon.sprite = currentPowerup.image;
                break;
            case 2:
                player2PowerupIcon.sprite = currentPowerup.image;
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
