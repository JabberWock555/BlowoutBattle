using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseBlowerController
{

    //serialize
    [SerializeField] private float chargeRate = 1f;
    [SerializeField] private float disChargeRate = 3f;

    //private
    //references
    BaseBlowerInputs playerInputs;
    CoOpUIPanelHandler coOpUIPanelHandler;
    BasePowerUp powerUp, usedPowerUp;
    UIManager uiManager;
    PlayerUIRef playerUIref;

    [Header("Power ups controller")]
    PowerUpType currentPowerUpType = PowerUpType.None;
    bool isBubbleMySide = false;
    [Header("SmashPower")]
    [SerializeField] float smashPowerMultiplierToBlowForce = 2f;

    protected override void Awake()
    {
        base.Awake();
        playerInputs = GetComponent<BaseBlowerInputs>();
        uiManager = GameManager.Instance?.uiManager;
        coOpUIPanelHandler = uiManager?.coOpUIPanelHandler;

        if (GameManager.Instance)
            GamePlayManager.Instance.activatePowerUPAction += ActivatePower;



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
            if (powerUp != null && ActivatePowerConditions() && !GamePlayManager.Instance.isPowerUPActive)
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
            if (other.TryGetComponent(out BasePowerUp powerUpRef))
                powerUp = powerUpRef;
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
            GamePlayManager.Instance.activatePowerUPAction -= ActivatePower;
    }


    #region PowerUps States

    private void SwichPowerUp(BasePowerUp newPowrerUp)
    {
        powerUp = newPowrerUp;
        coOpUIPanelHandler.SetPowerupIcon(playerUIref, powerUp.powerUpSO);
        currentPowerUpType = newPowrerUp.powerUpSO.powerUpType;
    }

    bool IsBubbleMySide()
    {
        if (playerID == 1 && transform.position.x < 0 && bubbleRef.transform.position.x < 0)
        {
            return true;
        }
        else if (playerID == 2 && transform.position.x > 0 && bubbleRef.transform.position.x > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ActivatePowerConditions()
    {
        switch (currentPowerUpType)
        {
            case PowerUpType.BonusPoint:
                return true;
            case PowerUpType.Freeze:
                return !IsBubbleMySide();
            case PowerUpType.Smash:
                return IsBubbleMySide();
            default:
                return false;
        }

    }

    protected override void ActivatePower(BasePowerUp powerUp)
    {
        if (powerUp == null)
        {
            return;
        }


        switch (currentPowerUpType)
        {
            case PowerUpType.BonusPoint:
                break;
            case PowerUpType.Freeze:
                break;
            case PowerUpType.Smash:
                SmashPowerUP();
                break;
            default:
                break;


        }


        GamePlayManager.Instance.isPowerUPActive = true;
        usedPowerUp = powerUp;
        powerUp = null;
        coOpUIPanelHandler.PowerUpUsed(playerUIref);
        DeactivatePower(usedPowerUp);

    }

    #region smashpower
    private void SmashPowerUP()
    {
        blowForce *= smashPowerMultiplierToBlowForce;
    }
    private void EndSmashPowerUP()
    {
        blowForce /= smashPowerMultiplierToBlowForce;
    }
    #endregion

    #region FreezPower
    private void FreezPowerUP()
    {

    }

    private void EndFreezPowerUP()
    {

    }
    #endregion



    protected override void DeactivatePower(BasePowerUp usedPowerUp)
    {
        StartCoroutine(CoolDownPower(usedPowerUp));
    }

    IEnumerator CoolDownPower(BasePowerUp usedPowerUp)
    {
        yield return new WaitForSeconds(usedPowerUp.powerUpSO.coolDownTime);

        switch (currentPowerUpType)
        {
            case PowerUpType.BonusPoint:

                break;
            case PowerUpType.Freeze:

                break;
            case PowerUpType.Smash:
                EndSmashPowerUP();
                break;
            default:
                break;
        }
        if (GamePlayManager.Instance)
        {
            GamePlayManager.Instance.deactivatePowerUPAction?.Invoke(usedPowerUp);
            GamePlayManager.Instance.isPowerUPActive = false;
        }

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

    #endregion
}