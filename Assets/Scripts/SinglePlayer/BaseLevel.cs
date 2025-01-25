using UnityEngine;

public class BaseLevel : MonoBehaviour
{
    public virtual void InitializeLevel() { }
    public virtual void ResetLevel() { }

    public virtual void StartLevel() { }

    public virtual void EndLevel()
    {

    }
}
