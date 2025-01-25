using UnityEngine;

public class PlayerController : BaseBlowerController
{
    private BaseBlowerInputs playerInputs;

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
            maxFuel -= fuelDecreaseRate * Time.fixedDeltaTime;
            uiManager.SetFuelMeter(playerID, maxFuel);
            // BlowerMoveByBlow(hit);
        }
        else
        {
            if (blowVFX.isPlaying)
                blowVFX.Stop();
        }
    }

}
