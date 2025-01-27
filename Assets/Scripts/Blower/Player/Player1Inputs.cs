using UnityEngine;

public class Player1Inputs : BaseBlowerInputs
{

    protected override void OnEnable()
    {
        base.OnEnable();

        inputActions.P1Movement.Enable();
        inputActions.P1Movement.PlayerOneMovement.performed += i => rotationInput = i.ReadValue<float>();

        //blowing
        inputActions.P1Movement.BlowerBlow.performed += i => isBlowerONInput = true;
        inputActions.P1Movement.BlowerBlow.canceled += i => isBlowerONInput = false;

        //powerUps
        inputActions.P1Movement.BlowerBlow.performed += i => isPowerUpInput = true;
        inputActions.P1Movement.BlowerBlow.canceled += i => isPowerUpInput = false;


    }

}
