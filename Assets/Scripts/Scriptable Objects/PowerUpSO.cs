using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Powerups", menuName = "Scriptable Objects/Powerups")]
public class PowerUpSO : ScriptableObject
{
    public PowerUpType powerUpType;
    public Image image;
    public float coolDownTime;
}
