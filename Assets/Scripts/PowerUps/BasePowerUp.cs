using System;
using UnityEngine;

public enum PowerUpType { None, BonusPoint, Freeze, Smash }

public class BasePowerUp : MonoBehaviour
{

    private float stayForSeconds = 10f;
    private float deactivateTimer;

    public PowerUpType powerUpType;

    public PowerUpSO powerUpSO;




    private void Start()
    {
        deactivateTimer = stayForSeconds;
    }

    private void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        deactivateTimer -= Time.deltaTime;
        if (deactivateTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void ActivatePowerUp()
    {
        Debug.Log("PowerUp Activated");
    }


}
