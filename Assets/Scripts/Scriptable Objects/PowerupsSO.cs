using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Powerups", menuName = "Scriptable Objects/Powerups")]
public class PowerupsSO : ScriptableObject
{
    [System.Serializable]
    public class Powerup
    {
        public Sprite image;
        public PowerupType type;
    }

    public Powerup[] powerupsArray;

    public enum PowerupType
    {
        None,
        Shield,
        SpeedBoost,
        ScoreBoost
    }
}
