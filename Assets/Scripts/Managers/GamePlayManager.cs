using System;
using UnityEngine;

public class GamePlayManager : MonoSingletonGeneric<GamePlayManager>
{
    public Action<BasePowerUp> activatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public Action<BasePowerUp> deactivatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public bool isPowerUPActive = false;
}
