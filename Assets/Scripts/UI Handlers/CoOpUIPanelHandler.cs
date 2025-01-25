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

    public void SetChargeMeter(CoOpPlayerUI playerUI, float fuelPercent)
    {
        playerUI.chargeBar.fillAmount = fuelPercent / 100f;
    }
    
    public void SetPowerupIcon(CoOpPlayerUI playerUI, PowerUpSO powerUpSo)
    {
        playerUI.powerUp = powerUpSo.image;
    }

    public void SetScore(CoOpPlayerUI playerUI, int score)
    {
        playerUI.playerScore.text = score.ToString();
    }


    #region Testing

    [ContextMenu("TestChargeBar")]
    public void TestChargeBar()
    {
        SetChargeMeter(player2UI, 60);    
    }
    
    #endregion


}
