using UnityEngine;
using UnityEngine.InputSystem;


public class BaseBlowerInputs : MonoBehaviour
{
    //serialize
    public float rotationInput = 0f;
    public bool isBlowerON = false;
    public bool isPowerUpUsed = false;

    //private
    protected PlayerInputAction inputActions;


    protected virtual void Awake()
    {
        //inputActions = GetComponent<PlayerInputAction>();
    }

    protected virtual void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerInputAction();
            inputActions.Enable();
        }



    }
    protected virtual void OnDisable()
    {
        inputActions.Disable();
    }
}
