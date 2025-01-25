using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseBlowerController
{

    //serialize
    [SerializeField] private float chargeRate = 1f;
    [SerializeField] private float disChargeRate = 3f;

    //private
    private BaseBlowerInputs playerInputs;
    private BasePowerUp currentPowerUp;
    private CoOpUIPanelHandler coOpUIPanelHandler;
    private BasePowerUp powerUp;

    UIManager uiManager;

    PlayerUIRef playerUIref;

    protected override void Awake()
    {
        base.Awake();
        playerInputs = GetComponent<BaseBlowerInputs>();
        uiManager = GameManager.Instance?.uiManager;
        coOpUIPanelHandler = uiManager?.coOpUIPanelHandler;

        if (GameManager.Instance)
            GamePlayManager.Instance.activatePowerUPAction += UsePowerUps;
    }


    private void Start()
    {
        DeterMineFuelMeter();
    }
    // Update is called once per frame
    private void Update()
    {
        BlowerRotation(playerInputs.rotationInput);


        if (playerInputs.isPowerUpInput)
        {
            if (powerUp != null)
                GamePlayManager.Instance.activatePowerUPAction?.Invoke(powerUp);
        }
    }
    private void FixedUpdate()
    {

        if (playerInputs.isBlowerONInput)
        {
            BlowerONBlowBubble();
            coOpUIPanelHandler.decreaseChargeMeter(playerUIref, disChargeRate);
        }
        else
        {
            coOpUIPanelHandler.IncreaseChargeMeter(playerUIref, chargeRate);
            if (blowVFX.isPlaying)
                blowVFX.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (GameManager.Instance.gameState == GameMode.Coop)
        {

            powerUp = other.GetComponent<BasePowerUp>();
            if (powerUp == null)
            {

                return;
            }
            SwichPowerUp(powerUp);
            Destroy(other.gameObject);
        }
    }


    private void OnDestroy()
    {
        if (GameManager.Instance)
            GamePlayManager.Instance.activatePowerUPAction -= UsePowerUps;
    }


    #region PowerUps States

    private void SwichPowerUp(BasePowerUp newPowrerUp)
    {
        powerUp = newPowrerUp;
        coOpUIPanelHandler.SetPowerupIcon(playerUIref, powerUp.powerUpSO);

    }

    protected override void UsePowerUps(BasePowerUp powerUp)
    {
        powerUp = null;
    }

    #endregion


    #region UI

    void DeterMineFuelMeter()
    {
        switch (playerID)
        {

            case 1:
                playerUIref = uiManager.coOpUIPanelHandler.player1UI;
                break;
            case 2:
                playerUIref = uiManager.coOpUIPanelHandler.player2UI;
                break;
            case 3:
                //playerUIref = uiManager.coOpUIPanelHandler.soloPlayerUI;
                break;


        }


    }


    void SetPowerUPUI(PlayerUIRef playerUIref, PowerUpSO powerUpSo)
    {
        coOpUIPanelHandler.SetPowerupIcon(playerUIref, powerUpSo);
    }



    #endregion
}