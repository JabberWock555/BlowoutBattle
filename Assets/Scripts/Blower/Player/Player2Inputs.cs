using UnityEngine;

public class Player2Inputs : BaseBlowerInputs
{

    protected override void OnEnable()
    {
        base.OnEnable();

        inputActions.P2Movement.Enable();
        inputActions.P2Movement.PlayerOneMovement.performed += i => rotationInput = i.ReadValue<float>();

        //blowing
        inputActions.P2Movement.BlowerBlow.performed += i => isBlowerON = true;
        inputActions.P2Movement.BlowerBlow.canceled += i => isBlowerON = false;

        //powerUps
        inputActions.P2Movement.BlowerBlow.performed += i => isBlowerON = true;
        inputActions.P2Movement.BlowerBlow.canceled += i => isBlowerON = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
