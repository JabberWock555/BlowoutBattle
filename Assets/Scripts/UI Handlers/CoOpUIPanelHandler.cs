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
    private GameObject[] bubbleCountIcons;

    private void Start()
    {
        AddMaxToBubbleDisplay();
    }

    //for single player
    public PlayerUIRef soloPlayerUI;


    #region Charge UI
    public void decreaseChargeMeter(PlayerUIRef playerUI, float chargeValue)
    {
        playerUI.chargeBar.fillAmount -= chargeValue * Time.deltaTime;
    }

    public void IncreaseChargeMeter(PlayerUIRef playerUI, float chargeValue)
    {
        playerUI.chargeBar.fillAmount += chargeValue * Time.deltaTime;
    }

    #endregion

    public void SetPowerupIcon(PlayerUIRef playerUI, PowerUpSO powerUpSo)
    {
        playerUI.powerUpImage.enabled = true;
        playerUI.powerUpImage = powerUpSo.image;
    }

    public void PowerUpUsed(PlayerUIRef playerUIRef)
    {
        playerUIRef.powerUpImage.sprite = null;
        playerUIRef.powerUpImage.enabled = false;
    }

    public void SetScore(PlayerUIRef playerUI, int score)
    {
        playerUI.playerScore.text = score.ToString();
    }

    public void RemoveOneBubbleIcon()
    {
        for (int i = bubbleCountIcons.Length - 1; i >= 0; i--)
        {
            if (bubbleCountIcons[i] != null)
            {
                Destroy(bubbleCountIcons[i]);
                bubbleCountIcons[i] = null;
                break;
            }
        }
    }

    public void AddMaxToBubbleDisplay()
    {
        int maxBounce = 3;

        bubbleCountIcons = new GameObject[maxBounce];
        for (int i = 0; i < maxBounce; i++)
        {
            bubbleCountIcons[i] = Instantiate(bubbleCountIcon, bubbleCountIcon.transform.parent);
            bubbleCountIcons[i].SetActive(true);
        }
    }


    #region Testing

    [ContextMenu("TestChargeBar")]
    public void TestChargeBar()
    {
        decreaseChargeMeter(player2UI, 60);
    }

    #endregion


}
