using Unity.VisualScripting;
using UnityEngine;

public class FreezePowerUp : BasePowerUp
{
    [SerializeField] private float freezeTime = 3f;
    private float freezeTimer;
    
    private void Start()
    {
        freezeTimer = freezeTime;
    }
}
