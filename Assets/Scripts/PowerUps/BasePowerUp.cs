using System;
using UnityEngine;

public enum PowerUpType { None, BonusPoint, Freeze, SpeedUp }

public class BasePowerUp : MonoBehaviour
{
    private float stayForSeconds = 10f;
    private float destroyTimer;

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
