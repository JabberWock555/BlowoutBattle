using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseBlowerController
{

    //serialize
    [SerializeField] private float chargeRate = 1f;
    [SerializeField] private float disChargeRate = 3f;
    private float totalCharging = 1f;

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
            CoOpManager.Instance.activatePowerUPAction += ActivatePower;

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
            if (powerUp != null && !CoOpManager.Instance.isPowerUPActive)
                CoOpManager.Instance.activatePowerUPAction?.Invoke(powerUp);
        }
    }
    private void FixedUpdate()
    {
        if (playerInputs.isBlowerONInput && totalCharging > 0f)
        {
            BlowerONBlowBubble();

            totalCharging -= disChargeRate * Time.fixedDeltaTime;
            totalCharging = Mathf.Clamp(totalCharging, 0f, 1f); // Clamp the charging to avoid negative values
            coOpUIPanelHandler.SetCharging(playerUIref, totalCharging);

        }
        else if (!playerInputs.isBlowerONInput)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            if (totalCharging < 1f)
            {
                totalCharging += chargeRate * Time.deltaTime;
                totalCharging = Mathf.Clamp(totalCharging, 0f, 1f);
                coOpUIPanelHandler.SetCharging(playerUIref, totalCharging);

            }
            if (blowVFX.isPlaying)
                blowVFX.Stop();
        }


        if (playerInputs.isPowerUpInput)
        {
            if (powerUp != null && !CoOpManager.Instance.isPowerUPActive)
                powerUp.ActivatePowerUp();
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
            other.gameObject.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        if (GameManager.Instance)
            CoOpManager.Instance.activatePowerUPAction -= ActivatePower;
    }


    #region PowerUps States

    private void SwichPowerUp(BasePowerUp newPowrerUp)
    {
        powerUp = newPowrerUp;
        coOpUIPanelHandler.SetPowerupIcon(playerUIref, powerUp.powerUpSO);
        currentPowerUpType = newPowrerUp.powerUpSO.powerUpType;
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


        CoOpManager.Instance.isPowerUPActive = true;
        usedPowerUp = powerUp;
        powerUp = null;
        coOpUIPanelHandler.PowerUpUsed(playerUIref);
        DeactivatePower(usedPowerUp);

    }

    #region smashpower
    private void SmashPowerUP()
    {
        blowForce *= smashPowerMultiplierToBlowForce;
        Debug.Log("SmashPowerUP");
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
        if (CoOpManager.Instance)
        {
            CoOpManager.Instance.deactivatePowerUPAction?.Invoke(usedPowerUp);
            CoOpManager.Instance.isPowerUPActive = false;
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