using SABI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[System.Serializable]
public class PlayerUIRef
{
    public Image chargeBar;
    public Image powerUpImage;
    public TextMeshProUGUI playerScore;
}


public class CoOpUIPanelHandler : MonoBehaviour
{
    public PlayerUIRef player1UI;
    public PlayerUIRef player2UI;


    [SerializeField] private GameObject bubbleCountIcon;
    [SerializeField] GameObject[] bubbleCountIcons;

    int bounceCount = 0;


    private void Awake()
    {
        player1UI.powerUpImage.enabled = false;
        player2UI.powerUpImage.enabled = false;
    }

    private void Start()
    {
        GameManager.Instance.uiManager.countDownTimerUI.gameObject.SetActive(true);
        GameManager.Instance.uiManager.countDownTimerUI.StartCountDown();

        this.DelayedExecution(4f, () => InitializeUI());

    }

    void InitializeUI()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        AddMaxToBubbleDisplay();
        CoOpManager.Instance?.SpawnBubble(0);
    }

    #region Charge UI

    public void SetCharging(PlayerUIRef playerUI, float chargeValue)
    {
        playerUI.chargeBar.fillAmount = chargeValue;
    }

    public float GetCharging(PlayerUIRef playerUIRef) => playerUIRef.chargeBar.fillAmount;

    #endregion

    public void SetPowerupIcon(PlayerUIRef playerUI, PowerUpSO powerUpSo)
    {
        playerUI.powerUpImage.enabled = true;
        playerUI.powerUpImage.sprite = powerUpSo.image;
    }

    public void PowerUpUsed(PlayerUIRef playerUIRef)
    {
        playerUIRef.powerUpImage.sprite = null;
        playerUIRef.powerUpImage.enabled = false;
    }

    public void SetScore(int playerID, int score = 1)
    {
        if (playerID == 1)
        {
            CoOpManager.Instance.player1Score += score;
            player1UI.playerScore.text = CoOpManager.Instance.player1Score.ToString();
        }
        else
        {
            CoOpManager.Instance.player2Score += score;
            player2UI.playerScore.text = CoOpManager.Instance.player2Score.ToString();
        }
    }

    public void RemoveOneBubbleIcon()
    {
        bubbleCountIcons[bounceCount].SetActive(false);
        bounceCount++;
    }

    public void AddMaxToBubbleDisplay()
    {
        foreach (var item in bubbleCountIcons)
        {
            item.SetActive(true);
        }
        bounceCount = 0;

    }



}
