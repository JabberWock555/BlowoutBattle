using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseBlowerController
{
    private BaseBlowerInputs playerInputs;
    private BasePowerUp currentPowerUp;

    UIManager uiManager;


    protected override void Awake()
    {
        base.Awake();
        playerInputs = GetComponent<BaseBlowerInputs>();
        uiManager = GameManager.Instance?.uiManager;
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
            /*maxFuel -= fuelDecreaseRate * Time.fixedDeltaTime;
            uiManager.SetFuelMeter(playerID, maxFuel);*/
            // BlowerMoveByBlow(hit);
        }
        else
        {
            if (blowVFX.isPlaying)
                blowVFX.Stop();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out BasePowerUp basePowerUp))
        {
            currentPowerUp = basePowerUp;
            Sprite currentSprite = other.GetComponent<SpriteRenderer>().sprite; 
            Destroy(other.gameObject);
            
            var panelHandler = uiManager.coOpUIPanelHandler;
            if (playerID == 1)
            {
                panelHandler.SetPowerupIcon(panelHandler.player1UI, currentSprite);
            }
            else
            {
                panelHandler.SetPowerupIcon(panelHandler.player2UI, currentSprite);
            }
        }
        
    }

}
