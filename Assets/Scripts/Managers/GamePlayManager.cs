using System;
using UnityEngine;

public class GamePlayManager : MonoSingletonGeneric<GamePlayManager>
{
    public Action<BasePowerUp> activatePowerUPAction = new Action<BasePowerUp>(delegate { });
}
