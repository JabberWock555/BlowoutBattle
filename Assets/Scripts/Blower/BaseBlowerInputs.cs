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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
