using System;
using UnityEngine;

public class CoOpManager : MonoSingletonGeneric<CoOpManager>
{
    public Action<BasePowerUp> activatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public Action<BasePowerUp> deactivatePowerUPAction = new Action<BasePowerUp>(delegate { });
    public bool isPowerUPActive = false;


    [SerializeField] BubbleSpawnner bubbleSpawnner;

    public int player1Score = 0;
    public int player2Score = 0;

    public void SpawnBubble(int point)
    {

        bubbleSpawnner.SpawnBubble(point);
    }





}
