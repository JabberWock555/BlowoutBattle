using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static string Player1Name;
    public static string Player2Name;
    public static GameMode PlayMode;

    [SerializeField] private TMP_InputField player1InputName;
    [SerializeField] private TMP_InputField player2InputName;
    
    public enum GameMode
    {
        SinglePlayer,
        Coop
    }
    public void LoadSceneSolo(string sceneName)
    {
        PlayMode = GameMode.SinglePlayer;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneCoop(string sceneName)
    {
        if (string.IsNullOrWhiteSpace(player1InputName.text) || string.IsNullOrWhiteSpace(player2InputName.text))
        {
            Debug.Log("Enter Player Names");
            return;
        }
        
        Player1Name = player1InputName.text;
        Player2Name = player2InputName.text;
        PlayMode = GameMode.Coop;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu_Adi");
        GameManager.Instance.UnpauseGame();
    }
    
}
