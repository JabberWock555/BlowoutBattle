using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[System.Serializable]
public class PlayerUIRef
{
    public Image chargeBar;
    public Image powerUp;
    public TextMeshProUGUI playerScore;
}


public class CoOpUIPanelHandler : MonoBehaviour
{
    //for CoOp
    public PlayerUIRef player1UI;
    public PlayerUIRef player2UI;

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
        playerUI.powerUp = powerUpSo.image;
    }

    public void SetScore(PlayerUIRef playerUI, int score)
    {
        playerUI.playerScore.text = score.ToString();
    }


    #region Testing

    [ContextMenu("TestChargeBar")]
    public void TestChargeBar()
    {
        decreaseChargeMeter(player2UI, 60);
    }

    #endregion


}
