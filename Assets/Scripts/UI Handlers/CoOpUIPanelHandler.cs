using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[System.Serializable]
public class CoOpPlayerUI
{
    public Image chargeBar;
    public Image powerUp;
    public TextMeshProUGUI playerScore;
}


public class CoOpUIPanelHandler : MonoBehaviour
{
    public CoOpPlayerUI player1UI;
    public CoOpPlayerUI player2UI;
    
    [SerializeField] private GameObject bubbleCountIcon;
    private GameObject[] bubbleCountIcons;

    private void Start()
    {
        AddMaxToBubbleDisplay();
    }

    public void SetChargeMeter(CoOpPlayerUI playerUI, float fuelPercent)
    {
        playerUI.chargeBar.fillAmount = fuelPercent / 100f;
    }
    
    public void SetPowerupIcon(CoOpPlayerUI playerUI, Sprite sprite)
    {
        playerUI.powerUp.sprite = sprite;
    }

    public void SetScore(CoOpPlayerUI playerUI, int score)
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
        SetChargeMeter(player2UI, 60);    
    }
    
    #endregion


}
