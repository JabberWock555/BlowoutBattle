using UnityEngine;

public class BaseBlowerController : MonoBehaviour
{
    //private
    Rigidbody rb;



    #region Unity methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }


    private void FixedUpdate()
    {

    }

    #endregion


    #region Mechanics

    protected virtual void BlowerMovement()
    {

    }


    protected virtual void BlowerRotation()
    {

    }

    protected virtual void BlowerON()
    {

    }

    protected virtual void UsePowerUps()
    {

    }


    #endregion

}
