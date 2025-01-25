using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Powerups", menuName = "Scriptable Objects/Powerups")]
public class PowerupsSO : ScriptableObject
{
    [System.Serializable]
    public class Powerup
    {
        public Sprite image;
        public PowerUpType type;
    }

    public Powerup[] powerupsArray;
}
