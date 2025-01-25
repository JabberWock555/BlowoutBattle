using UnityEngine;

public class Player2Inputs : BaseBlowerInputs
{

    protected override void OnEnable()
    {
        base.OnEnable();

        inputActions.P2Movement.Enable();
        inputActions.P2Movement.PlayerOneMovement.performed += i => rotationInput = i.ReadValue<float>();

        //blowing
        inputActions.P2Movement.BlowerBlow.performed += i => isBlowerONInput = true;
        inputActions.P2Movement.BlowerBlow.canceled += i => isBlowerONInput = false;

        //powerUps
        inputActions.P2Movement.BlowerBlow.performed += i => isBlowerONInput = true;
        inputActions.P2Movement.BlowerBlow.canceled += i => isBlowerONInput = false;
    }


}
