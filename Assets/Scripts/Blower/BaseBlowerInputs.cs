using UnityEngine;


public class BaseBlowerInputs : MonoBehaviour
{
    //serialize
    [SerializeField] protected float movemntInput = 0f;
    [SerializeField] protected float rotationInput = 0f;

    //private
    protected PlayerInputAction inputActions;


    private void Awake()
    {
        inputActions = GetComponent<PlayerInputAction>();
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
