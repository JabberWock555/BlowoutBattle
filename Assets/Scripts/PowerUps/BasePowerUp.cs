using System;
using UnityEngine;

public enum PowerUpType { None, BonusPoint, Freeze, Smash }

public class BasePowerUp : MonoBehaviour
{

    private float stayForSeconds = 10f;
    private float destroyTimer;

    public PowerUpType powerUpType;

    public PowerUpSO powerUpSO;



    private void Start()
    {
        destroyTimer = stayForSeconds;
    }

    private void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }


}
