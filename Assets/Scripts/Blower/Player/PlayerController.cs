using UnityEngine;

public class PlayerController : BaseBlowerController
{

    //serialize
    [SerializeField] private float chargeRate = 1f;
    [SerializeField] private float disChargeRate = 3f;

    //private
    private BaseBlowerInputs playerInputs;
    private BasePowerUp currentPowerUp;
    private CoOpUIPanelHandler coOpUIPanelHandler;

    UIManager uiManager;

    PlayerUIRef playerUIref;

    protected override void Awake()
    {
        base.Awake();
        playerInputs = GetComponent<BaseBlowerInputs>();
        uiManager = GameManager.Instance?.uiManager;
        coOpUIPanelHandler = uiManager?.coOpUIPanelHandler;
    }

    private void Start()
    {
        DeterMineFuelMeter();
    }
    // Update is called once per frame
    private void Update()
    {
        BlowerRotation(playerInputs.rotationInput);

    }
    private void FixedUpdate()
    {

        if (playerInputs.isBlowerON)
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
        BasePowerUp basePowerUp = other.GetComponent<BasePowerUp>();
        if (basePowerUp == null)
        {

            return;
        }

        currentPowerUp = basePowerUp;
        Destroy(other.gameObject);
    }




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